using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExcelTools
{

    public class FileInformation
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    class MainWindowData
    {
        public static string[] formatList = new string[] { "Lua", "Csv", "Xml", "Json" };
        public static string[] encodeList = new string[] { "UTF-8", "GB2312" };

        public static List<FileInformation> FileList = new List<FileInformation>();



        public static void LoadFileList()
        {
            FileList.Clear();
            if (!Directory.Exists(GetRootPath("ExcelPath")))
            {
                return;
            }

            GetAllExcelFiles(new DirectoryInfo(GetRootPath("ExcelPath")));
        }
        public static string GetRootPath(string s)
        {
            FileStream strm;
            try
            {
                strm = new FileStream(@"./Config/FilePath.xml", FileMode.Open);
            }
            catch
            {
                //文件不存在 停止加载
                return null;
            }
            DataSet data = new DataSet();
            data.ReadXml(strm, XmlReadMode.Auto);
            string path = data.Tables["FilePath"].Rows[0][s].ToString();
            strm.Close();
            return path;
        }

        public static void SaveRootPath(string s, string path)
        {
            FileStream strm;
            strm = new FileStream(@"./Config/FilePath.xml", FileMode.OpenOrCreate);
            DataSet data = new DataSet();
            data.ReadXml(strm, XmlReadMode.Auto);
            data.Tables["FilePath"].Rows[0][s] = path;
            strm.Close();

            using (FileStream fileStream = new FileStream(@"./Config/FilePath.xml", FileMode.Create, FileAccess.Write))
            {
                data.WriteXml(fileStream);
            }
        }

        private static void GetAllExcelFiles(DirectoryInfo dir)
        {
            FileInfo[] allFile = dir.GetFiles();
            foreach (FileInfo fi in allFile)
            {
                if (fi.Extension.ToUpper() == ".XLSX" || fi.Extension.ToUpper() == ".XLS")
                {
                    FileList.Add(new FileInformation { FileName = fi.Name, FilePath = fi.FullName });
                }
            }
            DirectoryInfo[] allDir = dir.GetDirectories();
            foreach (DirectoryInfo d in allDir)
            {
                GetAllExcelFiles(d);
            }
        }

        static Queue taskList = new Queue();
        static Scripts.DialogWindow.DialogWindow bardia;
        static int maxtaskNum = 0;
        static int completeNum = 0;
        public static void StartConvert(List<string> exl, string Format, string Encode,string[] strList)
        {
            if (exl == null)
                return;

            for (int i = 0; i < exl.Count; i++)
            {
                for (int x = 0; x < FileList.Count; x++)
                {
                    if (exl[i] == FileList[x].FileName)
                        taskList.Enqueue(FileList[x]);
                }

            }
            maxtaskNum = taskList.Count;
            bardia = new Scripts.DialogWindow.DialogWindow("导出中. . .");
            bardia.InitProgressBar();
            bardia.UpdateBarValue(taskList.Count, 0);
            completeNum = 0;
            Thread tr = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < taskList.Count; i++)
                {
                    ThreadPool.QueueUserWorkItem(state => getQueue(Format, Encode, strList));
                }
            }))
            {
                IsBackground = true
            };
            tr.Start();
            bardia.ShowDialog();
        }

        private static void getQueue(string Format, string Encode,string[] strList)
        {
            lock (taskList)
            {
                if (taskList.Count > 0)
                {
                    string output = GetRootPath("OutputPath");
                    FileInformation Info = (FileInformation)taskList.Dequeue();
                    ExcelUtility excel = new ExcelUtility(Info);

                    Encoding encoding = Encoding.GetEncoding(Encode);

                    if (Format == "Json")
                    {
                        output = string.Format("{0}/Json", output);
                    }
                    else if (Format == "Csv")
                    {
                        output = string.Format("{0}/Csv", output);
                    }
                    else if (Format == "Xml")
                    {
                        output = string.Format("{0}/Xml", output);
                    }
                    else if (Format == "Lua")
                    {
                        output = string.Format("{0}/Lua", output);
                        excel.ConvertToLua(output, encoding, strList);
                    }
                    completeNum++;
                }

                //计数
                if (bardia != null)
                    bardia.BeginInvoke(new MethodInvoker(() => { bardia.UpdateBarValue(maxtaskNum, completeNum); }));
            }
        }
    }
}
