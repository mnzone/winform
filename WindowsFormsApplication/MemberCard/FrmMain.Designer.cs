namespace MemberCard
{
    partial class FrmMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnMemberCard = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRecharge = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRecords = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMemberSearch = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbReNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNetworkStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSalesLog = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.labNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.labStatus = new System.Windows.Forms.Label();
            this.labCreatedAt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labExpire = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbAuto = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbTerm = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.gpGoods = new System.Windows.Forms.GroupBox();
            this.panelGoods = new System.Windows.Forms.Panel();
            this.gbStepPanel = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesLog)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpGoods.SuspendLayout();
            this.gbStepPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(54, 54);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnMemberCard,
            this.tsBtnRecharge,
            this.toolStripButton2,
            this.tsBtnRecords,
            this.tsBtnMemberSearch,
            this.tsBtnAdd,
            this.tsbReNew,
            this.tsBtnUpdate,
            this.tsBtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1261, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnMemberCard
            // 
            this.tsBtnMemberCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnMemberCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMemberCard.Name = "tsBtnMemberCard";
            this.tsBtnMemberCard.Size = new System.Drawing.Size(72, 22);
            this.tsBtnMemberCard.Text = "会员卡管理";
            this.tsBtnMemberCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnMemberCard.Click += new System.EventHandler(this.tsBtnMemberCard_Click);
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
            // toolStripButton2
            // 
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton2.Text = "会员卡延期";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnRecords
            // 
            this.tsBtnRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRecords.Name = "tsBtnRecords";
            this.tsBtnRecords.Size = new System.Drawing.Size(84, 22);
            this.tsBtnRecords.Text = "查询消费记录";
            this.tsBtnRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnMemberSearch
            // 
            this.tsBtnMemberSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnMemberSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMemberSearch.Name = "tsBtnMemberSearch";
            this.tsBtnMemberSearch.Size = new System.Drawing.Size(84, 22);
            this.tsBtnMemberSearch.Text = "导出消费数据";
            this.tsBtnMemberSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(60, 22);
            this.tsBtnAdd.Text = "添加商品";
            this.tsBtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbReNew
            // 
            this.tsbReNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsbReNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReNew.Name = "tsbReNew";
            this.tsbReNew.Size = new System.Drawing.Size(60, 22);
            this.tsbReNew.Text = "卡片回收";
            this.tsbReNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnUpdate
            // 
            this.tsBtnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdate.Name = "tsBtnUpdate";
            this.tsBtnUpdate.Size = new System.Drawing.Size(60, 22);
            this.tsBtnUpdate.Text = "更新系统";
            this.tsBtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnUpdate.Click += new System.EventHandler(this.tsBtnUpdate_Click);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(60, 22);
            this.tsBtnExit.Text = "退出系统";
            this.tsBtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslNetworkStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1261, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel1.Text = "数据服务状态：";
            // 
            // tsslNetworkStatus
            // 
            this.tsslNetworkStatus.Name = "tsslNetworkStatus";
            this.tsslNetworkStatus.Size = new System.Drawing.Size(32, 17);
            this.tsslNetworkStatus.Text = "就绪";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSalesLog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(0, 371);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(987, 137);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作记录";
            // 
            // dgvSalesLog
            // 
            this.dgvSalesLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvSalesLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesLog.Location = new System.Drawing.Point(3, 25);
            this.dgvSalesLog.Name = "dgvSalesLog";
            this.dgvSalesLog.ReadOnly = true;
            this.dgvSalesLog.RowHeadersVisible = false;
            this.dgvSalesLog.RowTemplate.Height = 23;
            this.dgvSalesLog.Size = new System.Drawing.Size(981, 109);
            this.dgvSalesLog.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 40.60914F;
            this.Column1.HeaderText = "时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 159.3909F;
            this.Column2.HeaderText = "描述";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.numValue);
            this.groupBox4.Controls.Add(this.btnSubmit);
            this.groupBox4.Controls.Add(this.labNo);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.panelStatus);
            this.groupBox4.Controls.Add(this.labCreatedAt);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.labBalance);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.labExpire);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.labType);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(0, 130);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(987, 241);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "会员卡信息";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(675, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 27);
            this.label11.TabIndex = 12;
            this.label11.Text = "本次使用：";
            // 
            // numValue
            // 
            this.numValue.Location = new System.Drawing.Point(798, 82);
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(82, 29);
            this.numValue.TabIndex = 11;
            this.numValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(886, 76);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 40);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "使用";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // labNo
            // 
            this.labNo.AutoSize = true;
            this.labNo.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labNo.Location = new System.Drawing.Point(793, 35);
            this.labNo.Name = "labNo";
            this.labNo.Size = new System.Drawing.Size(132, 27);
            this.labNo.TabIndex = 10;
            this.labNo.Text = "1000000001";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(675, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 27);
            this.label10.TabIndex = 9;
            this.label10.Text = "会员卡号：";
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.labStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(3, 138);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(981, 100);
            this.panelStatus.TabIndex = 8;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStatus.Location = new System.Drawing.Point(147, 25);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(160, 46);
            this.labStatus.TabIndex = 0;
            this.labStatus.Text = "准备就绪";
            // 
            // labCreatedAt
            // 
            this.labCreatedAt.AutoSize = true;
            this.labCreatedAt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCreatedAt.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labCreatedAt.Location = new System.Drawing.Point(465, 82);
            this.labCreatedAt.Name = "labCreatedAt";
            this.labCreatedAt.Size = new System.Drawing.Size(126, 27);
            this.labCreatedAt.TabIndex = 7;
            this.labCreatedAt.Text = "2014-04-10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(347, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 27);
            this.label8.TabIndex = 6;
            this.label8.Text = "开卡日期：";
            // 
            // labBalance
            // 
            this.labBalance.AutoSize = true;
            this.labBalance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labBalance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labBalance.Location = new System.Drawing.Point(465, 35);
            this.labBalance.Name = "labBalance";
            this.labBalance.Size = new System.Drawing.Size(44, 27);
            this.labBalance.TabIndex = 5;
            this.labBalance.Text = "0次";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(347, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "剩余次数：";
            // 
            // labExpire
            // 
            this.labExpire.AutoSize = true;
            this.labExpire.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labExpire.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labExpire.Location = new System.Drawing.Point(146, 82);
            this.labExpire.Name = "labExpire";
            this.labExpire.Size = new System.Drawing.Size(126, 27);
            this.labExpire.TabIndex = 3;
            this.labExpire.Text = "2014-04-10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(28, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "到期时间：";
            // 
            // labType
            // 
            this.labType.AutoSize = true;
            this.labType.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labType.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labType.Location = new System.Drawing.Point(146, 35);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(72, 27);
            this.labType.TabIndex = 1;
            this.labType.Text = "已就绪";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员卡种类：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbAuto);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbTerm);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 105);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询录入区";
            // 
            // ckbAuto
            // 
            this.ckbAuto.AutoSize = true;
            this.ckbAuto.Location = new System.Drawing.Point(616, 41);
            this.ckbAuto.Name = "ckbAuto";
            this.ckbAuto.Size = new System.Drawing.Size(93, 25);
            this.ckbAuto.TabIndex = 8;
            this.ckbAuto.Text = "自动提交";
            this.ckbAuto.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(512, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 46);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbTerm
            // 
            this.cmbTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerm.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTerm.FormattingEnabled = true;
            this.cmbTerm.Items.AddRange(new object[] {
            "会员卡号",
            "会员姓名",
            "手机号码",
            "身份证号"});
            this.cmbTerm.Location = new System.Drawing.Point(12, 31);
            this.cmbTerm.Name = "cmbTerm";
            this.cmbTerm.Size = new System.Drawing.Size(132, 39);
            this.cmbTerm.TabIndex = 6;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyword.Location = new System.Drawing.Point(160, 29);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(346, 46);
            this.txtKeyword.TabIndex = 5;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // gpGoods
            // 
            this.gpGoods.Controls.Add(this.panelGoods);
            this.gpGoods.Controls.Add(this.gbStepPanel);
            this.gpGoods.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpGoods.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpGoods.Location = new System.Drawing.Point(987, 25);
            this.gpGoods.Name = "gpGoods";
            this.gpGoods.Size = new System.Drawing.Size(274, 483);
            this.gpGoods.TabIndex = 19;
            this.gpGoods.TabStop = false;
            this.gpGoods.Text = "商品出售";
            // 
            // panelGoods
            // 
            this.panelGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGoods.Location = new System.Drawing.Point(3, 25);
            this.panelGoods.Name = "panelGoods";
            this.panelGoods.Size = new System.Drawing.Size(268, 367);
            this.panelGoods.TabIndex = 1;
            // 
            // gbStepPanel
            // 
            this.gbStepPanel.Controls.Add(this.btnNext);
            this.gbStepPanel.Controls.Add(this.btnPrevious);
            this.gbStepPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbStepPanel.Location = new System.Drawing.Point(3, 392);
            this.gbStepPanel.Name = "gbStepPanel";
            this.gbStepPanel.Size = new System.Drawing.Size(268, 88);
            this.gbStepPanel.TabIndex = 0;
            this.gbStepPanel.TabStop = false;
            this.gbStepPanel.Text = "操作面板";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(145, 29);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(105, 53);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(22, 29);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(105, 53);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "上一页";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 530);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpGoods);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmView_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesLog)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpGoods.ResumeLayout(false);
            this.gbStepPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnMemberCard;
        private System.Windows.Forms.ToolStripButton tsBtnRecharge;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton tsBtnRecords;
        private System.Windows.Forms.ToolStripButton tsBtnMemberSearch;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsbReNew;
        private System.Windows.Forms.ToolStripButton tsBtnUpdate;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNetworkStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvSalesLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numValue;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label labNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Label labCreatedAt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labExpire;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckbAuto;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbTerm;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.GroupBox gpGoods;
        private System.Windows.Forms.Panel panelGoods;
        private System.Windows.Forms.GroupBox gbStepPanel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Timer timer;
    }
}