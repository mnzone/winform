namespace Loader
{
    partial class FrmLoader
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.labStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 1000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.BackColor = System.Drawing.Color.Transparent;
            this.labStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labStatus.ForeColor = System.Drawing.SystemColors.Window;
            this.labStatus.Location = new System.Drawing.Point(0, 328);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(59, 12);
            this.labStatus.TabIndex = 0;
            this.labStatus.Text = "加载中...";
            // 
            // FrmLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 340);
            this.Controls.Add(this.labStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "启动中";
            this.Load += new System.EventHandler(this.FrmLoader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.Label labStatus;
    }
}

