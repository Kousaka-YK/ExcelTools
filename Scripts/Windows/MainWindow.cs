using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExcelTools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //初始化
            InitData();
            InitMenu();
            InitTextTips();
            InitComboBox();
            InitBtnClickEvent();
            InitExcelList();
        }

        private void InitData()
        {
            MainWindowData.LoadFileList();
        }

        private void InitMenu()
        {
            MenuStripControl.InitMenu(menuStrip);
        }

        private void InitTextTips()
        {
            text_1.Text = string.Format("请选择输出文件格式");
            text_2.Text = string.Format("请选择文件编码");
        }

        private void InitComboBox()
        {
            comboFormat.DataSource = MainWindowData.formatList;
            comboEncode.DataSource = MainWindowData.encodeList;
        }

        private void InitBtnClickEvent()
        {
            Btn_Ref.Click += new EventHandler(RefBtnClick);
            Btn_Out.Click += new EventHandler(OutBtnClick);
            buttonAssign.Click += new EventHandler(outGroup);
        }

        private void InitExcelList()
        {
            excelListBox.Items.Clear();
            for (int i = 0; i < MainWindowData.FileList.Count; i++)
            {
                excelListBox.Items.Add(MainWindowData.FileList[i].FileName, true);
            }
        }

        private void RefBtnClick(object sender, EventArgs e)
        {
            //刷新
            InitData();
            InitExcelList();
        }

        private void OutBtnClick(object sender, EventArgs e)
        {
            //导出
            ExportList(null);
        }

        private void ExportList(string[] strList)
        {
            List<string> exl = new List<string>();
            for (int i = 0; i < excelListBox.Items.Count; i++)
            {
                if (excelListBox.GetItemChecked(i))
                    exl.Add(excelListBox.Items[i].ToString());
            }
            MainWindowData.StartConvert(exl, comboFormat.Text, comboEncode.Text, strList);
        }

        private void outGroup(object sender, EventArgs s)
        {
            //集合导出
            string str = textBox_1.Text;
            if (str != null && str != "")
            {
                string[] strList = str.Split(',');
                ExportList(strList);
            }
        }
    }
}
