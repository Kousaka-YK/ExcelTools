using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExcelTools
{
    public partial class SettingWindow : Form
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void SettingWindows_Load(object sender, EventArgs e)
        {
            InitMenuList();
        }

        private void InitMenuList()
        {
            menuList.Items.Add("导入导出地址");

            menuList.SelectedIndexChanged += new EventHandler(ClickMenuList);
        }

        private void ClickMenuList(object sender, EventArgs e)
        {
            ListBox item = (ListBox)sender;
            if (item.SelectedItem == null)
                return;
            MenuClickFunc(item.SelectedItem.ToString());
        }

        TextBox textBox_1 = new TextBox();
        TextBox textBox_2 = new TextBox();
        private void MenuClickFunc(string itemName)
        {
            if (itemName == "导入导出地址")
            {
                this.SuspendLayout();
                Label text_1 = new Label();
                text_1.Text = "Excel根目录";
                text_1.Parent = panel_1;
                text_1.Size = new Size(80, 15);
                text_1.Location = new Point(10, 20);
                
                textBox_1.Text = MainWindowData.GetRootPath("ExcelPath");
                textBox_1.Parent = panel_1;
                textBox_1.Size = new Size(200, 15);
                textBox_1.Location = new Point(100, 15);
                textBox_1.Click += new EventHandler(OpenPath);


                Label text_2 = new Label();
                text_2.Text = "导出地址";
                text_2.Parent = panel_1;
                text_2.Size = new Size(80, 15);
                text_2.Location = new Point(10, 40);
                
                textBox_2.Text = MainWindowData.GetRootPath("OutputPath");
                textBox_2.Parent = panel_1;
                textBox_2.Size = new Size(200, 15);
                textBox_2.Location = new Point(100, 40);
                textBox_2.Click += new EventHandler(OpenPath);

                Button save = new Button();
                save.Parent = panel_1;
                save.Text = "保存";
                save.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                save.Location = new Point(panel_1.Width-200, panel_1.Height-40);
                save.Click += new EventHandler(Save_Btn_Click);

                Button cance = new Button();
                cance.Parent = panel_1;
                cance.Text = "取消";
                cance.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                cance.Location = new Point(panel_1.Width - 100, panel_1.Height - 40);
                cance.Click += new EventHandler(Cancel_Btn_Click);

                this.ResumeLayout(false);
            }
        }

        private void OpenPath(object sender, EventArgs e)
        {
            string folderPath = null;
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                folderPath = folder.SelectedPath;
            }
            else
            {
                return;
            }
            
            if (sender == textBox_1)
            {
                textBox_1.Text = folderPath;
            }
            else if (sender == textBox_2)
            {
                textBox_2.Text = folderPath;
            }
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            //保存到xml
            MainWindowData.SaveRootPath("ExcelPath", textBox_1.Text);
            MainWindowData.SaveRootPath("OutputPath", textBox_2.Text);
            this.Close();
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
