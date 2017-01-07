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
    public partial class FrmPostponed : Form
    {

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                findCard(this.txtKeyword.Text.Trim());
            }
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
        }

        private void initBll()
        {
            BllFactory.DLLBasePath = Application.StartupPath;
            recordBll = BllFactory.GetMemberCardRecordBll();
            cardBll = BllFactory.GetMemberCardBll();
        }

        private void FrmPostponed_Load(object sender, EventArgs e)
        {
            this.btnSubmit.Enabled = false;
            initBll();
        }
    }
}
