namespace MemberCard
{
    partial class FrmInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labExpire = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labCardNum = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labCardNo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labCategory = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labStatus = new System.Windows.Forms.Label();
            this.timerViewDisplay = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 458);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labExpire);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 276);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(755, 85);
            this.panel5.TabIndex = 4;
            // 
            // labExpire
            // 
            this.labExpire.AutoSize = true;
            this.labExpire.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labExpire.Location = new System.Drawing.Point(182, 25);
            this.labExpire.Name = "labExpire";
            this.labExpire.Size = new System.Drawing.Size(480, 75);
            this.labExpire.TabIndex = 1;
            this.labExpire.Text = "到期时间：未刷卡";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labCardNum);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 185);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(755, 85);
            this.panel4.TabIndex = 3;
            // 
            // labCardNum
            // 
            this.labCardNum.AutoSize = true;
            this.labCardNum.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCardNum.Location = new System.Drawing.Point(182, 13);
            this.labCardNum.Name = "labCardNum";
            this.labCardNum.Size = new System.Drawing.Size(480, 75);
            this.labCardNum.TabIndex = 1;
            this.labCardNum.Text = "剩余次数：未刷卡";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labCardNo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(755, 85);
            this.panel3.TabIndex = 2;
            // 
            // labCardNo
            // 
            this.labCardNo.AutoSize = true;
            this.labCardNo.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCardNo.Location = new System.Drawing.Point(182, 11);
            this.labCardNo.Name = "labCardNo";
            this.labCardNo.Size = new System.Drawing.Size(480, 75);
            this.labCardNo.TabIndex = 0;
            this.labCardNo.Text = "会员卡号：未刷卡";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labCategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 85);
            this.panel2.TabIndex = 1;
            // 
            // labCategory
            // 
            this.labCategory.AutoSize = true;
            this.labCategory.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCategory.Location = new System.Drawing.Point(182, 6);
            this.labCategory.Name = "labCategory";
            this.labCategory.Size = new System.Drawing.Size(480, 75);
            this.labCategory.TabIndex = 1;
            this.labCategory.Text = "会员类别：未刷卡";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 367);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 88);
            this.panel1.TabIndex = 0;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStatus.Location = new System.Drawing.Point(231, 16);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(144, 75);
            this.labStatus.TabIndex = 1;
            this.labStatus.Text = "就绪";
            // 
            // timerViewDisplay
            // 
            this.timerViewDisplay.Enabled = true;
            this.timerViewDisplay.Interval = 3000;
            // 
            // FrmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 458);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员信息显示";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInfo_Load);
            this.SizeChanged += new System.EventHandler(this.FrmInfo_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labExpire;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labCardNum;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labCardNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labCategory;
        private System.Windows.Forms.Timer timerViewDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labStatus;
    }
}