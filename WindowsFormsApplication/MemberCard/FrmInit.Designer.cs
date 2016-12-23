namespace MemberCard
{
    partial class FrmInit
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
            this.components = new System.ComponentModel.Container();
            this.btnSyn = new System.Windows.Forms.Button();
            this.timerSyn = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSyn
            // 
            this.btnSyn.Location = new System.Drawing.Point(12, 12);
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.Size = new System.Drawing.Size(101, 75);
            this.btnSyn.TabIndex = 0;
            this.btnSyn.Text = "数据同步";
            this.btnSyn.UseVisualStyleBackColor = true;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // timerSyn
            // 
            this.timerSyn.Interval = 6000;
            this.timerSyn.Tick += new System.EventHandler(this.timerSyn_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(119, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 75);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出系统";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 99);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSyn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInit";
            this.Text = "会员卡管理系统";
            this.Load += new System.EventHandler(this.FrmInit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSyn;
        private System.Windows.Forms.Timer timerSyn;
        private System.Windows.Forms.Button btnExit;
    }
}

