namespace MemberCard.Card
{
    partial class FrmManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManager));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslMemberCardNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddCard = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRecharge = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelay = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRecovery = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRecharge = new System.Windows.Forms.Button();
            this.btnDelay = new System.Windows.Forms.Button();
            this.btnRecovery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslMemberCardNum,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(656, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel1.Text = "当前会员卡数量：";
            // 
            // tsslMemberCardNum
            // 
            this.tsslMemberCardNum.ForeColor = System.Drawing.Color.Red;
            this.tsslMemberCardNum.Name = "tsslMemberCardNum";
            this.tsslMemberCardNum.Size = new System.Drawing.Size(15, 17);
            this.tsslMemberCardNum.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabel3.Text = "张";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(54, 54);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddCard,
            this.tsBtnRecharge,
            this.tsBtnDelay,
            this.tsBtnRecovery,
            this.tsBtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(656, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAddCard
            // 
            this.tsBtnAddCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnAddCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddCard.Name = "tsBtnAddCard";
            this.tsBtnAddCard.Size = new System.Drawing.Size(72, 22);
            this.tsBtnAddCard.Text = "添加会员卡";
            this.tsBtnAddCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnAddCard.Click += new System.EventHandler(this.tsBtnMemberCard_Click);
            // 
            // tsBtnRecharge
            // 
            this.tsBtnRecharge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnRecharge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRecharge.Name = "tsBtnRecharge";
            this.tsBtnRecharge.Size = new System.Drawing.Size(72, 22);
            this.tsBtnRecharge.Text = "会员卡充值";
            this.tsBtnRecharge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnRecharge.Click += new System.EventHandler(this.tsBtnRecharge_Click);
            // 
            // tsBtnDelay
            // 
            this.tsBtnDelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnDelay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelay.Name = "tsBtnDelay";
            this.tsBtnDelay.Size = new System.Drawing.Size(72, 22);
            this.tsBtnDelay.Text = "会员卡延期";
            this.tsBtnDelay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnDelay.Click += new System.EventHandler(this.tsBtnDelay_Click);
            // 
            // tsBtnRecovery
            // 
            this.tsBtnRecovery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnRecovery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRecovery.Name = "tsBtnRecovery";
            this.tsBtnRecovery.Size = new System.Drawing.Size(60, 22);
            this.tsBtnRecovery.Text = "卡片回收";
            this.tsBtnRecovery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnRecovery.Click += new System.EventHandler(this.tsBtnRecovery_Click);
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(36, 22);
            this.tsBtnClose.Text = "关闭";
            this.tsBtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRecharge);
            this.groupBox1.Controls.Add(this.btnDelay);
            this.groupBox1.Controls.Add(this.btnRecovery);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCardNo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // btnRecharge
            // 
            this.btnRecharge.Location = new System.Drawing.Point(371, 20);
            this.btnRecharge.Name = "btnRecharge";
            this.btnRecharge.Size = new System.Drawing.Size(75, 23);
            this.btnRecharge.TabIndex = 4;
            this.btnRecharge.Text = "充值";
            this.btnRecharge.UseVisualStyleBackColor = true;
            this.btnRecharge.Click += new System.EventHandler(this.btnRecharge_Click);
            // 
            // btnDelay
            // 
            this.btnDelay.Location = new System.Drawing.Point(290, 20);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(75, 23);
            this.btnDelay.TabIndex = 3;
            this.btnDelay.Text = "延期";
            this.btnDelay.UseVisualStyleBackColor = true;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // btnRecovery
            // 
            this.btnRecovery.Location = new System.Drawing.Point(209, 20);
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(75, 23);
            this.btnRecovery.TabIndex = 2;
            this.btnRecovery.Text = "收回";
            this.btnRecovery.UseVisualStyleBackColor = true;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "会员卡号：";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(83, 22);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(109, 21);
            this.txtCardNo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 225);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据显示";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column5,
            this.Column3,
            this.Column2});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(650, 205);
            this.dgvList.TabIndex = 2;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 76.51556F;
            this.Column4.HeaderText = "会员卡号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 60.70713F;
            this.Column1.HeaderText = "会员类型";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 71.547F;
            this.Column5.HeaderText = "卡片状态";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 113.9594F;
            this.Column3.HeaderText = "加卡时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 126.2709F;
            this.Column2.HeaderText = "最后操作时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // FrmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 332);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员卡管理";
            this.Load += new System.EventHandler(this.FrmManager_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMemberCardNum;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAddCard;
        private System.Windows.Forms.ToolStripButton tsBtnRecharge;
        private System.Windows.Forms.ToolStripButton tsBtnDelay;
        private System.Windows.Forms.ToolStripButton tsBtnRecovery;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRecharge;
        private System.Windows.Forms.Button btnDelay;
        private System.Windows.Forms.Button btnRecovery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}