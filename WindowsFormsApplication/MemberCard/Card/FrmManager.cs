using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IBLL;
using MemberCard.Trade;

namespace MemberCard.Card
{
    public partial class FrmManager : Form
    {
        private IMemberCardBLL bll = null;

        public FrmManager()
        {
            InitializeComponent();
        }

        private void tsBtnMemberCard_Click(object sender, System.EventArgs e)
        {
            FrmAdd frmAdd = new FrmAdd();
            frmAdd.ShowDialog();
        }

        private void tsBtnDelay_Click(object sender, System.EventArgs e)
        {
            FrmPostponed frmPostponed = new FrmPostponed();
            frmPostponed.ShowDialog();
        }

        private void tsBtnRecovery_Click(object sender, System.EventArgs e)
        {
            Trade.FrmRecovery frmRecovery = new Trade.FrmRecovery();
            frmRecovery.ShowDialog();
        }

        private void tsBtnRecharge_Click(object sender, System.EventArgs e)
        {
            FrmRecharge frmRechare = new FrmRecharge();
            frmRechare.ShowDialog();
        }

        private void tsBtnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmManager_Load(object sender, System.EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            bll = Common.BLLLoader.GetMemberCardBll();
            List<Models.MemberCard> cards = null;
            try
            {
                cards = bll.GetAllMemberCard();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "数据库不可用", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cards == null)
            {
                return;
            }

            this.dgvList.Rows.Clear();
            
            foreach (Models.MemberCard card in cards)
            {
                this.dgvList.Rows.Add(new String[]
                {
                    card.CardNo,
                    card.CategoryId.ToString(),
                    "",
                    card.CreatedAt.ToString(),
                    card.UpdatedAt.ToString()
                });
            }
            this.tsslMemberCardNum.Text = cards.Count.ToString();
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            Models.MemberCard card = this.getMemberCard(this.txtCardNo.Text.Trim());
            if (card == null)
            {
                return;
            }

            FrmRecovery frmRecovery = new FrmRecovery();
            frmRecovery.ShowDialog();
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            Models.MemberCard card = this.getMemberCard(this.txtCardNo.Text.Trim());
            if (card == null)
            {
                return;
            }
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {

            Models.MemberCard card = this.getMemberCard(this.txtCardNo.Text.Trim());
            if (card == null)
            {
                return;
            }

            FrmRecharge frmRecharge = new FrmRecharge(card);
            frmRecharge.ShowDialog();
        }

        /// <summary>
        /// 根据会员卡号获取会员卡信息
        /// </summary>
        /// <param name="no">卡号</param>
        /// <returns></returns>
        private Models.MemberCard getMemberCard(String no)
        {
            if (String.IsNullOrEmpty(no))
            {
                MessageBox.Show("请先输入卡号", "数据不完整", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Models.MemberCard card = null;
            try
            {
                card = bll.GetMemberCardByNo(no);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "数据库不可用", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return card;
        }
    }
}
