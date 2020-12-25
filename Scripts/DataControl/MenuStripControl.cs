using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExcelTools
{
    static class MenuStripControl
    {

        private static Dictionary<string, List<string>> menu = new Dictionary<string, List<string>> { { "文件", new List<string> { "设置", "退出" } },{"帮助", new List<string> {"关于"} }};
        public static void InitMenu(MenuStrip menuStrip)
        {
            foreach (string key in menu.Keys)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = key;
                menuStrip.Items.Add((ToolStripItem)mi);
                foreach (string value in menu[key])
                {
                    CreateMenuItem(mi, value);
                }
            }
        }

        private static void CreateMenuItem(ToolStripMenuItem mainMu, string s)
        {
            ToolStripMenuItem mi = new ToolStripMenuItem();
            mi.Text = s;
            mi.Tag = s;
            mainMu.DropDownItems.Add(mi);
            mi.Click += new EventHandler(MenuItemClick);
        }

        private static void MenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            string tag = mi.Tag as string;
            if (tag == "设置")
            {
                SettingWindow setWindow = new SettingWindow();
                setWindow.ShowDialog();
            }
            else if (tag == "关于")
            {
                
            }
            else if (tag == "退出")
            {
                Application.Exit();
            }
        }
    }
}
