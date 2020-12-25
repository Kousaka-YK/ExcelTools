using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcelTools.Scripts.DataControl
{
    public class CustomUtil
    {


        public static bool IsFileInUse(string url, bool needDialog = false)
        {
            bool inUse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(url, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                inUse = false;
            }
            catch
            {
                string path = url.Replace("/", "\\");
                if (needDialog)
                {
                    //EditorUtility.DisplayDialog("文件被占用", "文件 '" + path + "' 被占用，请先关闭对应的Excel！！！", "我知道了");
                }
                //LogDebugColor("文件 '" + path + "' 被占用，请先关闭对应的Excel！！！");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return inUse; //true表示正在使用,false没有使用  
        }


        public static void SaveTxt(string url, string content, Encoding encode, bool needDialog = false)
        {
            CheckPath(url);
            if (!IsFileInUse(url, needDialog))
            {
                File.WriteAllText(url, content, encode);
            }
        }

        public static void CheckPath(string url)
        {
            string[] arr = url.Split('/');
            string path = "";
            for (int i = 0; i < (arr.Length - 1); i++)
            {
                path += arr[i] + "/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
