namespace MemberCard.Trade
{
    partial class FrmRecharge
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
            this.timerFouce = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labMoney = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labMemberCardCategory = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labMemberCardNo = new System.Windows.Forms.Label();
            this.labTip = new System.Windows.Forms.Label();
            this.validTime = new System.Windows.Forms.DateTimePicker();
            this.cmbMoney = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerFouce
            // 
            this.timerFouce.Interval = 1000;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(161, 381);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 46);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labMoney);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 94);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "充值次数";
            // 
            // labMoney
            // 
            this.labMoney.AutoSize = true;
            this.labMoney.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMoney.Location = new System.Drawing.Point(156, 41);
            this.labMoney.Name = "labMoney";
            this.labMoney.Size = new System.Drawing.Size(175, 25);
            this.labMoney.TabIndex = 10;
            this.labMoney.Text = "帐户剩余次数：0元";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labMemberCardCategory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labMemberCardNo);
            this.groupBox1.Controls.Add(this.labTip);
            this.groupBox1.Controls.Add(this.validTime);
            this.groupBox1.Controls.Add(this.cmbMoney);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.txtMoney);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 276);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请刷卡";
            // 
            // labMemberCardCategory
            // 
            this.labMemberCardCategory.AutoSize = true;
            this.labMemberCardCategory.Location = new System.Drawing.Point(131, 97);
            this.labMemberCardCategory.Name = "labMemberCardCategory";
            this.labMemberCardCategory.Size = new System.Drawing.Size(58, 21);
            this.labMemberCardCategory.TabIndex = 18;
            this.labMemberCardCategory.Text = "请刷卡";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "会员卡种类：";
            // 
            // labMemberCardNo
            // 
            this.labMemberCardNo.AutoSize = true;
            this.labMemberCardNo.Location = new System.Drawing.Point(131, 44);
            this.labMemberCardNo.Name = "labMemberCardNo";
            this.labMemberCardNo.Size = new System.Drawing.Size(58, 21);
            this.labMemberCardNo.TabIndex = 16;
            this.labMemberCardNo.Text = "请刷卡";
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Location = new System.Drawing.Point(200, 217);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(58, 21);
            this.labTip.TabIndex = 15;
            this.labTip.Text = "有效期";
            this.labTip.Visible = false;
            // 
            // validTime
            // 
            this.validTime.Location = new System.Drawing.Point(284, 211);
            this.validTime.Name = "validTime";
            this.validTime.Size = new System.Drawing.Size(166, 29);
            this.validTime.TabIndex = 14;
            this.validTime.Visible = false;
            // 
            // cmbMoney
            // 
            this.cmbMoney.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoney.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMoney.FormattingEnabled = true;
            this.cmbMoney.Location = new System.Drawing.Point(131, 144);
            this.cmbMoney.Name = "cmbMoney";
            this.cmbMoney.Size = new System.Drawing.Size(127, 46);
            this.cmbMoney.TabIndex = 13;
            this.cmbMoney.SelectedIndexChanged += new System.EventHandler(this.cmbMoney_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "充值次数：";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(332, 144);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(118, 46);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "确认充值";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtMoney
            // 
            this.txtMoney.Enabled = false;
            this.txtMoney.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMoney.Location = new System.Drawing.Point(264, 144);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(62, 46);
            this.txtMoney.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "会员卡号：";
            // 
            // FrmRecharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 440);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRecharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员卡充值";
            this.Load += new System.EventHandler(this.FrmRecharge_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmRecharge_KeyPress);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerFouce;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labMoney;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.DateTimePicker validTime;
        private System.Windows.Forms.ComboBox cmbMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labMemberCardNo;
        private System.Windows.Forms.Label labMemberCardCategory;
        private System.Windows.Forms.Label label4;
    }
}