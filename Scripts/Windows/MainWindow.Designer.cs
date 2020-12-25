namespace ExcelTools
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.text_1 = new System.Windows.Forms.Label();
            this.text_2 = new System.Windows.Forms.Label();
            this.comboFormat = new System.Windows.Forms.ComboBox();
            this.comboEncode = new System.Windows.Forms.ComboBox();
            this.Btn_Ref = new System.Windows.Forms.Button();
            this.Btn_Out = new System.Windows.Forms.Button();
            this.ListPlane = new System.Windows.Forms.Panel();
            this.excelListBox = new System.Windows.Forms.CheckedListBox();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.textBox_1 = new System.Windows.Forms.TextBox();
            this.ListPlane.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(202, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // text_1
            // 
            this.text_1.AutoSize = true;
            this.text_1.Location = new System.Drawing.Point(13, 38);
            this.text_1.Name = "text_1";
            this.text_1.Size = new System.Drawing.Size(41, 12);
            this.text_1.TabIndex = 1;
            this.text_1.Text = "text_1";
            // 
            // text_2
            // 
            this.text_2.AutoSize = true;
            this.text_2.Location = new System.Drawing.Point(13, 69);
            this.text_2.Name = "text_2";
            this.text_2.Size = new System.Drawing.Size(41, 12);
            this.text_2.TabIndex = 2;
            this.text_2.Text = "label1";
            // 
            // comboFormat
            // 
            this.comboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFormat.FormattingEnabled = true;
            this.comboFormat.Location = new System.Drawing.Point(146, 38);
            this.comboFormat.Name = "comboFormat";
            this.comboFormat.Size = new System.Drawing.Size(121, 20);
            this.comboFormat.TabIndex = 3;
            // 
            // comboEncode
            // 
            this.comboEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEncode.FormattingEnabled = true;
            this.comboEncode.Location = new System.Drawing.Point(146, 64);
            this.comboEncode.Name = "comboEncode";
            this.comboEncode.Size = new System.Drawing.Size(121, 20);
            this.comboEncode.TabIndex = 4;
            // 
            // Btn_Ref
            // 
            this.Btn_Ref.Location = new System.Drawing.Point(308, 35);
            this.Btn_Ref.Name = "Btn_Ref";
            this.Btn_Ref.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ref.TabIndex = 5;
            this.Btn_Ref.Text = "刷新";
            this.Btn_Ref.UseVisualStyleBackColor = true;
            // 
            // Btn_Out
            // 
            this.Btn_Out.Location = new System.Drawing.Point(400, 35);
            this.Btn_Out.Name = "Btn_Out";
            this.Btn_Out.Size = new System.Drawing.Size(75, 23);
            this.Btn_Out.TabIndex = 6;
            this.Btn_Out.Text = "导出全部";
            this.Btn_Out.UseVisualStyleBackColor = true;
            // 
            // ListPlane
            // 
            this.ListPlane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPlane.Controls.Add(this.excelListBox);
            this.ListPlane.Location = new System.Drawing.Point(0, 121);
            this.ListPlane.Name = "ListPlane";
            this.ListPlane.Size = new System.Drawing.Size(798, 354);
            this.ListPlane.TabIndex = 7;
            // 
            // excelListBox
            // 
            this.excelListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excelListBox.BackColor = System.Drawing.SystemColors.Menu;
            this.excelListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelListBox.CheckOnClick = true;
            this.excelListBox.FormattingEnabled = true;
            this.excelListBox.IntegralHeight = false;
            this.excelListBox.Location = new System.Drawing.Point(0, 0);
            this.excelListBox.Name = "excelListBox";
            this.excelListBox.Size = new System.Drawing.Size(798, 354);
            this.excelListBox.TabIndex = 1;
            this.excelListBox.ThreeDCheckBoxes = true;
            this.excelListBox.UseTabStops = false;
            // 
            // buttonAssign
            // 
            this.buttonAssign.Location = new System.Drawing.Point(308, 69);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(75, 23);
            this.buttonAssign.TabIndex = 8;
            this.buttonAssign.Text = "导出指定";
            this.buttonAssign.UseVisualStyleBackColor = true;
            // 
            // textBox_1
            // 
            this.textBox_1.Location = new System.Drawing.Point(400, 71);
            this.textBox_1.Name = "textBox_1";
            this.textBox_1.Size = new System.Drawing.Size(388, 21);
            this.textBox_1.TabIndex = 9;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.textBox_1);
            this.Controls.Add(this.buttonAssign);
            this.Controls.Add(this.ListPlane);
            this.Controls.Add(this.Btn_Out);
            this.Controls.Add(this.Btn_Ref);
            this.Controls.Add(this.comboEncode);
            this.Controls.Add(this.comboFormat);
            this.Controls.Add(this.text_2);
            this.Controls.Add(this.text_1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainWindow";
            this.Text = "ExcelTools";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ListPlane.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Label text_1;
        private System.Windows.Forms.Label text_2;
        private System.Windows.Forms.ComboBox comboFormat;
        private System.Windows.Forms.ComboBox comboEncode;
        private System.Windows.Forms.Button Btn_Ref;
        private System.Windows.Forms.Button Btn_Out;
        private System.Windows.Forms.Panel ListPlane;
        private System.Windows.Forms.CheckedListBox excelListBox;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.TextBox textBox_1;
    }
}

