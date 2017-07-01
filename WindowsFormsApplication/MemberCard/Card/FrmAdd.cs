using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using IBLL;
using MemberCard.Common;
using Models;

namespace MemberCard.Card
{
    public partial class FrmAdd : Form
    {
        private IMemberCardCategoryBLL categoryBll = null;
        private IMemberCardBLL cardBll = null;

        public FrmAdd()
        {
            InitializeComponent();
        }

        private void setLabelMsg(String msg, Color color)
        {
            this.labMsg.Text = msg;
            this.labMsg.Left = (this.Width - this.labMsg.Width) / 2;
            this.labMsg.ForeColor = color;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            String msg = null;
            if (String.IsNullOrEmpty(this.txtNo.Text.Trim()))
            {
                msg = "卡号为必填项";
            }else if (this.txtNo.Text.Trim().Length != 10)
            {
                msg = "卡号长度必须为11位";
            }

            if (msg != null)
            {
                this.setLabelMsg(msg, Color.DarkRed);
                return;
            }

            Models.MemberCard card = new Models.MemberCard();
            card.CategoryId = (int) this.cbxCategory.SelectedValue;
            card.CardNo = this.txtNo.Text.Trim();
            bool flag = false;
            try
            {
                flag = cardBll.AddMemberCard(card);
            }
            catch (ArgumentNullException err)
            {
                msg = err.Message;
            }
            catch (ArgumentException err)
            {
                msg = err.Message;
            }
            catch (Exception err)
            {
                msg = err.Message;
            }

            if ( ! flag)
            {
                this.setLabelMsg(msg, Color.DarkRed);
                return;
            }
            this.setLabelMsg("卡号保存成功", Color.Green);
            this.txtNo.Clear();
            this.txtNo.Focus();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void FrmAdd_Load(object sender, System.EventArgs e)
        {
            categoryBll = BLLLoader.GetMemberCardCategoryBll();
            cardBll = BLLLoader.GetMemberCardBll();

            List<MemberCardCategory> list = categoryBll.GetAllMemberCardCategory();
            this.cbxCategory.DisplayMember = "Name";
            this.cbxCategory.ValueMember = "Id";
            this.cbxCategory.DataSource = list;
        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnSave_Click(this.btnSave, null);
            }
        }
    }
}
