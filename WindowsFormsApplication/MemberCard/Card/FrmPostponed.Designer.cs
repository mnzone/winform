namespace MemberCard.Card
{
    partial class FrmPostponed
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labValidTime = new System.Windows.Forms.Label();
            this.labMemberNo = new System.Windows.Forms.Label();
            this.validTime = new System.Windows.Forms.DateTimePicker();
            this.labExpireDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerFouce = new System.Windows.Forms.Timer(this.components);
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labValidTime);
            this.groupBox1.Controls.Add(this.labMemberNo);
            this.groupBox1.Controls.Add(this.validTime);
            this.groupBox1.Controls.Add(this.labExpireDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 235);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请刷卡";
            // 
            // labValidTime
            // 
            this.labValidTime.AutoSize = true;
            this.labValidTime.Location = new System.Drawing.Point(120, 172);
            this.labValidTime.Name = "labValidTime";
            this.labValidTime.Size = new System.Drawing.Size(58, 21);
            this.labValidTime.TabIndex = 18;
            this.labValidTime.Text = "请刷卡";
            // 
            // labMemberNo
            // 
            this.labMemberNo.AutoSize = true;
            this.labMemberNo.Location = new System.Drawing.Point(120, 52);
            this.labMemberNo.Name = "labMemberNo";
            this.labMemberNo.Size = new System.Drawing.Size(58, 21);
            this.labMemberNo.TabIndex = 17;
            this.labMemberNo.Text = "请刷卡";
            // 
            // validTime
            // 
            this.validTime.Location = new System.Drawing.Point(124, 166);
            this.validTime.Name = "validTime";
            this.validTime.Size = new System.Drawing.Size(200, 29);
            this.validTime.TabIndex = 14;
            // 
            // labExpireDate
            // 
            this.labExpireDate.AutoSize = true;
            this.labExpireDate.Location = new System.Drawing.Point(120, 114);
            this.labExpireDate.Name = "labExpireDate";
            this.labExpireDate.Size = new System.Drawing.Size(42, 21);
            this.labExpireDate.TabIndex = 16;
            this.labExpireDate.Text = "就绪";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "当前有效期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "延期至：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "会员卡号：";
            // 
            // timerFouce
            // 
            this.timerFouce.Interval = 1000;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(100, 250);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(149, 46);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "确认延期";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FrmPostponed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 313);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPostponed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员卡延期";
            this.Load += new System.EventHandler(this.FrmPostponed_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPostponed_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker validTime;
        private System.Windows.Forms.Label labExpireDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerFouce;
        private System.Windows.Forms.Label labMemberNo;
        private System.Windows.Forms.Label labValidTime;
        private System.Windows.Forms.Button btnSubmit;
    }
}