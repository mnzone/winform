using System;
using System.Windows.Forms;
using DelegateLibrary;
using FactoryImpl;
using IBLL;
using Models;

namespace MemberCard.Trade
{
    public partial class FrmRecovery : FrmBase
    {
        private String cardNo;
        private DateTime lastTime = DateTime.Now;
        private int timeSpanSeconds = 0;

        private Models.MemberCard card;
        private IMemberCardRecordBLL recordBll = null;
        private IMemberCardBLL cardBll = null;
        private IMemberCardCategoryBLL catBll = null;
        private CallbackMsg callback = null;

        public CallbackMsg Callback
        {
            get
            {
                return callback;
            }

            set
            {
                callback = value;
            }
        }

        public FrmRecovery()
        {
            InitializeComponent();
        }

        public FrmRecovery(Models.MemberCard card): this()
        {
            this.card = card;
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            if (this.card == null || this.card.Record == null)
            {
                MessageBox.Show("请先刷卡!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.btnRecovery.Enabled = false;
            this.card.Record.Status = Status.Disabled;
            this.card.Record.Balance = 0;
            if (this.recordBll.EditMemberCardRecord(this.card.Record))
            {
                MessageBox.Show("卡片已收回!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("卡片已收回失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRecovery_Load(object sender, EventArgs e)
        {
            this.btnRecovery.Enabled = false;
            this.KeyPreview = true;
            initBll();

            if (this.card == null)
            {
                return;
            }

            
            this.labNo.Text = this.card.CardNo.Trim();
            this.labBalance.Text = this.card.Record.Balance.ToString();
            this.labCategory.Text = this.card.Category.Name.Trim();
            this.labExpirt.Text = this.card.Record.ExpiredAt.ToString();
        }

        private void findCard(String no)
        {
            this.card = cardBll.GetMemberCardByNo(no);
            this.card.Record = this.card != null ? recordBll.GetMemberCardRecordByMemberCardId(this.card.Id) : null;
            this.card.Category = catBll.GetMemberCardCategoryById(this.card.CategoryId);

            String msg = null;

            if (this.card == null)
            {
                msg = "此卡不存在!";
            }
            else if (this.card.Record == null)
            {
                msg = "此卡未开户，请先开卡!";
            }

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.labNo.Text = this.card.CardNo.Trim();
            this.labBalance.Text = this.card.Record.Balance.ToString();
            this.labCategory.Text = this.card.Category.Name.Trim();
            this.labExpirt.Text = this.card.Record.ExpiredAt.ToString();
            this.btnRecovery.Enabled = true;
        }

        private void initBll()
        {
            BllFactory.DLLBasePath = Application.StartupPath;
            recordBll = BllFactory.GetMemberCardRecordBll();
            cardBll = BllFactory.GetMemberCardBll();
            catBll = BllFactory.GetMemberCardCategoryBll();
        }

        private void FrmRecovery_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((DateTime.Now - lastTime).Seconds > timeSpanSeconds)
            {
                cardNo = "";
            }

            lastTime = DateTime.Now;
            if (isKeyword(e.KeyChar))
            {
                if (e.KeyChar == 13)
                {
                    findCard(cardNo);
                    cardNo = "";
                }
                return;
            }

            cardNo += e.KeyChar.ToString();
        }

        
    }
}
