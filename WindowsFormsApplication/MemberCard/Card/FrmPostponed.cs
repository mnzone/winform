using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DelegateLibrary;
using FactoryImpl;
using IBLL;
using Tools;

namespace MemberCard.Card
{
    public partial class FrmPostponed : FrmBase
    {

        private String cardNo;
        private DateTime lastTime = DateTime.Now;
        private int timeSpanSeconds = 0;

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

        public FrmPostponed()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.card == null || this.card.Record == null)
            {
                return;
            }

            String msg = "会员卡已成功延期!";
            this.card.Record.ExpiredAt = TimeStamp.ConvertDateTimeInt(this.validTime.Value.Date.AddHours(23));
            if ( ! this.recordBll.EditMemberCardRecord(this.card.Record))
            {
                msg = "会员卡延期失败!";
            }

            MessageBox.Show(msg, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.btnSubmit.Enabled = false;
        }

        private void findCard(String no)
        {
            this.card = cardBll.GetMemberCardByNo(no);
            if (this.card != null)
            {
                this.card.Record = recordBll.GetMemberCardRecordByMemberCardId(this.card.Id);
            }

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

            this.labExpireDate.Text = TimeStamp.ConvertIntDateTime(this.card.Record.ExpiredAt).ToString("yyyy-MM-dd");
            this.btnSubmit.Enabled = true;

            this.labValidTime.Visible = false;
            this.validTime.Visible = true;
        }

        private void initBll()
        {
            BllFactory.DLLBasePath = Application.StartupPath;
            recordBll = BllFactory.GetMemberCardRecordBll();
            cardBll = BllFactory.GetMemberCardBll();
        }

        private void FrmPostponed_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.btnSubmit.Focus();

            this.labValidTime.Visible = true;
            this.validTime.Visible = false;
            this.btnSubmit.Enabled = false;
            initBll();
        }

        private void FrmPostponed_KeyPress(object sender, KeyPressEventArgs e)
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
