using System.Windows.Forms;
using System.Drawing;
using System;

namespace ExcelTools.Scripts.DialogWindow
{
    class DialogWindow : Form
    {
        private string headText = "Dialog";

        System.Timers.Timer timer;
        public DialogWindow(string text)
        {
            headText = text;
        }

        ProgressBar progressBar = new ProgressBar();
        public void UpdateBarValue(int maxValue, int curValue)
        {
            progressBar.Maximum = maxValue;
            progressBar.Value = curValue;

            if (progressBar.Value == progressBar.Maximum)
            {
                progressBar.Value = progressBar.Maximum;

                timer = new System.Timers.Timer(2000);
                //设置执行一次（false）还是一直执行(true)
                timer.AutoReset = true;
                //设置是否执行System.Timers.Timer.Elapsed事件
                timer.Enabled = true;
                //绑定Elapsed事件
                timer.Elapsed += new System.Timers.ElapsedEventHandler(CloseFrom);

            }
        }

        private void CloseFrom(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke(new Action(delegate
            {
                timer.Stop();
                this.Close();
            }));
        }

        public void InitProgressBar()
        {
            this.SuspendLayout();
            // progressBar
            this.progressBar.Location = new Point(4, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(376, 23);
            this.progressBar.TabIndex = 0;

            // ProcessBarWindow
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(384, 41);
            this.StartPosition = FormStartPosition.CenterParent;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Name = headText;
            this.Text = headText;
            //this.Load += new System.EventHandler(this.ProcessBar_Load);
            this.ResumeLayout(false);
        }
    }
}
