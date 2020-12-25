using System.Collections.Generic;
using Excel;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System;

namespace ExcelTools
{
    public class ExcelUtility
    {
        private DataSet mResultSet;
        private FileInformation excelFile;
        public ExcelUtility(FileInformation excelFile)
        {
            this.excelFile = excelFile;
            FileStream mStream = File.Open(excelFile.FilePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader mExcelReader = ExcelReaderFactory.CreateOpenXmlReader(mStream);
            mResultSet = mExcelReader.AsDataSet();
            mStream.Close();
        }
        public void ConvertToLua(string luaPath, Encoding encoding, string[] strList)
        {
            if (mResultSet.Tables.Count < 1)
                return;
            //分表遍历
            for (int k = 0; k < strList.Length; k++)
            {
                ConvertToLua(luaPath, encoding, strList[k]);
            }
        }

        private void CheckFile(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string PathFormat(string fileRoot, string sheetName)
        {
            string path;
            path = fileRoot + "/" + excelFile.FileName + "/" + sheetName;
            CheckFile(fileRoot + "/" + excelFile.FileName);
            return path;
        }

        private void ConvertToLua(string luaPath, Encoding encoding, string id)
        {
            string fileName = string.Format("Config{0}", id);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Clear();
            stringBuilder.Append(string.Format("local {0} =", fileName));
            stringBuilder.Append("{}\r\n");
            for (int i = 0; i < mResultSet.Tables.Count; i++)
            {
                stringBuilder.Append(string.Format("{0}.{1} = ", fileName, mResultSet.Tables[i].TableName));
                stringBuilder.Append("{\r\n");
                int rowCount = mResultSet.Tables[i].Rows.Count;
                int colCount = mResultSet.Tables[i].Columns.Count;
                for (int j = 3; j < rowCount; j++) //行
                {
                    if (mResultSet.Tables[i].Rows[j][0].ToString() == id)
                    {
                        stringBuilder.Append(string.Format("\t\t[{0}] = ", j - 2));
                        stringBuilder.Append("{");
                        for (int x = 0; x < colCount; x++)//列
                        {
                            string field = mResultSet.Tables[i].Rows[0][x].ToString();
                            if (mResultSet.Tables[i].Rows[j][x].ToString() != "" && field != "备注")
                            {
                                string str = LuaTypeCheck(mResultSet.Tables[i].Rows[2][x].ToString(), mResultSet.Tables[i].Rows[j][x].ToString());
                                stringBuilder.Append(string.Format("{0} = {1},", field, str));
                            }
                        }
                        stringBuilder.Append("},\r");
                    }
                }
                stringBuilder.Append("}\r\n");
            }
            stringBuilder.Append(string.Format("return\t{0}", fileName));

            string path = string.Format("{0}.lua", PathFormat(luaPath, fileName));
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, encoding))
                {
                    textWriter.Write(stringBuilder.ToString());
                }
            }
        }

        private void ConvertToLua(string luaPath, Encoding encoding)
        {
            for (int i = 0; i < mResultSet.Tables.Count; i++)
            {
                int rowCount = mResultSet.Tables[i].Rows.Count;
                int colCount = mResultSet.Tables[i].Columns.Count;
                for (int j = 3; j < rowCount; j++) //行
                {
                        for (int x = 0; x < colCount; x++)//列
                        {
                            string field = mResultSet.Tables[i].Rows[0][x].ToString();
                            if (mResultSet.Tables[i].Rows[j][x].ToString() != "" && field != "备注")
                            {
                                string str = LuaTypeCheck(mResultSet.Tables[i].Rows[2][x].ToString(), mResultSet.Tables[i].Rows[j][x].ToString());
                            }
                        }
                }
            }
        }

        private string LuaTypeCheck(string typeStr, string data)
        {
            string str = "";
            if (typeStr.IndexOf("int[]") != -1)
            {
                string[] s = data.Split(';');
                for (int i = 0; i < s.Length; i++)
                {
                    str = str + s[i] + ",";
                }
                str = "{" + str + "}";
            }
            else if (typeStr.IndexOf("int") != -1)
            {
                str = data;
            }
            else if (typeStr.IndexOf("float[]") != -1)
            {
                string[] s = data.Split(';');
                for (int i = 0; i < s.Length; i++)
                {
                    str = str + s[i] + ",";
                }
                str = "{" + str + "}";
            }
            else if (typeStr.IndexOf("float") != -1)
            {
                str = data;
            }
            else if (typeStr.IndexOf("string[]") != -1)
            {
                string[] s = data.Split(';');
                for (int i = 0; i < s.Length; i++)
                {
                    str = str + string.Format("\"{0} \"", s[i]) + ",";
                }
                str = "{" + str + "}";
            }
            else if (typeStr.IndexOf("string") != -1)
            {
                str = string.Format("\"{0} \"", data);
            }
            return str;
        }
    }
}
