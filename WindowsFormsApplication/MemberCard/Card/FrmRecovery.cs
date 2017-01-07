using System;
using System.Windows.Forms;
using DelegateLibrary;
using FactoryImpl;
using IBLL;
using Models;
using Tools;

namespace MemberCard.Card
{
    public partial class FrmRecovery : Form
    {
        private DateTime lastTime = DateTime.Now;
        private Models.MemberCard card;
        private IMemberCardRecordBLL recordBll = null;
        private IMemberCardBLL cardBll = null;
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

        private void txtKeywrod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                findCard(this.txtKeyword.Text.Trim());
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

        }

        private void findCard(String no)
        {
            this.card = cardBll.GetMemberCardByNo(no);
            this.card.Record = this.card != null ? recordBll.GetMemberCardRecordByMemberCardId(this.card.Id) : null;

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

            this.card.Record.Status = Status.Disabled;
            if (this.recordBll.EditMemberCardRecord(this.card.Record))
            {
                MessageBox.Show("卡片已收回!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("卡片已收回失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initBll()
        {
            BllFactory.DLLBasePath = Application.StartupPath;
            recordBll = BllFactory.GetMemberCardRecordBll();
            cardBll = BllFactory.GetMemberCardBll();
        }

        private void FrmRecovery_Load(object sender, EventArgs e)
        {
            initBll();
        }
    }
}
