namespace DataMigrations
{
    partial class FrmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnMigrationMember = new System.Windows.Forms.Button();
            this.btnMemberValue = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnWriterLog = new System.Windows.Forms.Button();
            this.btnReadRecord = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.labNone = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labOk = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 155);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(489, 95);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnMigrationMember);
            this.tabPage1.Controls.Add(this.btnMemberValue);
            this.tabPage1.Controls.Add(this.btnGo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(481, 69);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "会员数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnMigrationMember
            // 
            this.btnMigrationMember.Location = new System.Drawing.Point(104, 18);
            this.btnMigrationMember.Name = "btnMigrationMember";
            this.btnMigrationMember.Size = new System.Drawing.Size(123, 23);
            this.btnMigrationMember.TabIndex = 21;
            this.btnMigrationMember.Text = "开始迁移Member";
            this.btnMigrationMember.UseVisualStyleBackColor = true;
            this.btnMigrationMember.Click += new System.EventHandler(this.btnMigrationMember_Click);
            // 
            // btnMemberValue
            // 
            this.btnMemberValue.Location = new System.Drawing.Point(233, 18);
            this.btnMemberValue.Name = "btnMemberValue";
            this.btnMemberValue.Size = new System.Drawing.Size(123, 23);
            this.btnMemberValue.TabIndex = 20;
            this.btnMemberValue.Text = "开始迁移Member值";
            this.btnMemberValue.UseVisualStyleBackColor = true;
            this.btnMemberValue.Click += new System.EventHandler(this.btnMemberValue_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(19, 18);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(79, 23);
            this.btnGo.TabIndex = 11;
            this.btnGo.Text = "读原数据";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtId);
            this.tabPage2.Controls.Add(this.btnWriterLog);
            this.tabPage2.Controls.Add(this.btnReadRecord);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(481, 69);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "销售记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnWriterLog
            // 
            this.btnWriterLog.Location = new System.Drawing.Point(97, 23);
            this.btnWriterLog.Name = "btnWriterLog";
            this.btnWriterLog.Size = new System.Drawing.Size(123, 23);
            this.btnWriterLog.TabIndex = 23;
            this.btnWriterLog.Text = "开始迁移销售数据";
            this.btnWriterLog.UseVisualStyleBackColor = true;
            this.btnWriterLog.Click += new System.EventHandler(this.btnWriterLog_Click);
            // 
            // btnReadRecord
            // 
            this.btnReadRecord.Location = new System.Drawing.Point(12, 23);
            this.btnReadRecord.Name = "btnReadRecord";
            this.btnReadRecord.Size = new System.Drawing.Size(79, 23);
            this.btnReadRecord.TabIndex = 22;
            this.btnReadRecord.Text = "读原数据";
            this.btnReadRecord.UseVisualStyleBackColor = true;
            this.btnReadRecord.Click += new System.EventHandler(this.btnReadRecord_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtTarget);
            this.groupBox1.Controls.Add(this.txtSrc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 155);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(23, 106);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(442, 21);
            this.txtServer.TabIndex = 16;
            this.txtServer.Text = "server=localhost;user id=root;password=;database=feiyu;Connect Timeout=500;Charse" +
    "t=utf8;";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(23, 62);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(442, 21);
            this.txtTarget.TabIndex = 15;
            this.txtTarget.Text = "F:\\vs\\飞鱼游泳馆数据备份\\data.db";
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(23, 17);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(442, 21);
            this.txtSrc.TabIndex = 14;
            this.txtSrc.Text = "F:\\vs\\飞鱼游泳馆数据备份\\MemberCard.db";
            // 
            // labNone
            // 
            this.labNone.AutoSize = true;
            this.labNone.Location = new System.Drawing.Point(71, 329);
            this.labNone.Name = "labNone";
            this.labNone.Size = new System.Drawing.Size(11, 12);
            this.labNone.TabIndex = 25;
            this.labNone.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "未处理：";
            // 
            // labOk
            // 
            this.labOk.AutoSize = true;
            this.labOk.Location = new System.Drawing.Point(71, 299);
            this.labOk.Name = "labOk";
            this.labOk.Size = new System.Drawing.Size(11, 12);
            this.labOk.TabIndex = 23;
            this.labOk.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "已处理：";
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.Location = new System.Drawing.Point(71, 271);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(11, 12);
            this.labTotal.TabIndex = 21;
            this.labTotal.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "共计：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(248, 25);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 24;
            this.txtId.Text = "0";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 352);
            this.Controls.Add(this.labNone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMigrationMember;
        private System.Windows.Forms.Button btnMemberValue;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.Label labNone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWriterLog;
        private System.Windows.Forms.Button btnReadRecord;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtId;
    }
}

