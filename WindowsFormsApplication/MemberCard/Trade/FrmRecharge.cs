using System;
using System.Collections.Generic;
using FactoryImpl;
using System.Windows.Forms;
using DelegateLibrary;
using IBLL;
using Models;
using Tools;
using MemberCard = Models.MemberCard;

namespace MemberCard.Trade
{
    public partial class FrmRecharge : FrmBase
    {
        private Models.MemberCard card;
        private IMemberCardRecordBLL recordBll = null;
        private IMemberCardCategoryBLL catBll = null;
        private IMemberCardBLL cardBll = null;
        private IMemberCardCategoryValueBLL catValueBll = null;
        private ISaleLogBLL saleBll = null;
        private CallbackMsg callback = null;

        private String cardNo = "";
        private DateTime lastTime = DateTime.Now;
        private int timeSpanSeconds = 0;

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

        public FrmRecharge()
        {
            InitializeComponent();
        }
        public FrmRecharge(Models.MemberCard card) : this()
        {
            this.card = card;
        }

        private void initBll()
        {
            BllFactory.DLLBasePath = Application.StartupPath;
            recordBll = BllFactory.GetMemberCardRecordBll();
            catBll = BllFactory.GetMemberCardCategoryBll();
            catValueBll = BllFactory.GetMemberCardCategoryValueBll();
            cardBll = BllFactory.GetMemberCardBll();
            saleBll = BllFactory.GetSaleLogBll();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtMoney.Text.Trim()))
            {
                MessageBox.Show("请先选择充值次数及金额!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MemberCardCategoryValue cat = this.cmbMoney.SelectedItem as MemberCardCategoryValue;
            this.card.Record.Balance += cat.ValueNum;
            this.card.Record.BeginAt = TimeStamp.ConvertDateTimeInt(DateTime.Now.Date);
            this.card.Record.ExpiredAt = TimeStamp.ConvertDateTimeInt(this.validTime.Value.Date.AddHours(23));

            if (this.card.Record.Id > 0 ? recordBll.EditMemberCardRecord(this.card.Record) : recordBll.AddMemberCardRecord(this.card.Record))
            {
                SaleLog log = new SaleLog();
                log.CreatedAt = TimeStamp.ConvertDateTimeInt(DateTime.Now);
                log.MemberId = this.card.Id;
                log.MemberNo = this.card.CardNo;
                log.GoodsId = cat.GoodsId;
                log.Money = Convert.ToDecimal(this.txtMoney.Text.Trim());
                log.Summary = String.Format("卡号：{0}在{1}充值{2}元", this.card.CardNo, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), cat.Money);
                saleBll.AddLog(log);
                Callback(log.Summary);
                this.labMoney.Text = String.Format("帐户剩余次数：{0}次", this.card.Record.Balance.ToString());
            }

            this.btnSubmit.Enabled = false;
            this.card = null;
            MessageBox.Show("充值成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void FrmRecharge_Load(object sender, System.EventArgs e)
        {
            this.KeyPreview = true;

            this.initBll();

            this.loadData();

            this.btnSubmit.Enabled = this.card != null;
            this.labMemberCardNo.Text = this.card != null ? this.card.CardNo : "";

        }

        private void cmbMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            setMoneyAndNum();
        }

        private void loadData()
        {
            if (this.card == null)
            {
                return;
            }

            List<MemberCardCategoryValue> items = catValueBll.GetAllMemberCardCategoryValuesByCategoryId(this.card.CategoryId);
            this.cmbMoney.DisplayMember = "ValueNum";
            this.cmbMoney.ValueMember = "Money";
            this.cmbMoney.DataSource = items;
            setMoneyAndNum();
        }

        private void findCard(String no)
        {
            this.card = cardBll.GetMemberCardByNo(no);
            if (this.card != null)
            {
                this.card.Record = recordBll.GetMemberCardRecordByMemberCardId(this.card.Id);
                this.card.Category = catBll.GetMemberCardCategoryById(this.card.CategoryId);
            }
            

            String msg = null;

            if (this.card == null)
            {
                msg = "此卡不存在!";
            }

            if ( ! String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.card.Record == null || this.card.Record.Status == Status.Disabled)
            {
                DialogResult result = MessageBox.Show("此卡未开户，是否开卡?", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                this.card.Record = new MemberCardRecord();
                this.card.Record.MemberCardId = this.card.Id;
            }

            this.labMemberCardCategory.Text = this.card.Category.Name;
            this.labMoney.Text = String.Format("帐户剩余次数：{0}次", Convert.ToInt32(this.card.Record.Balance));
            this.btnSubmit.Enabled = true;
        }

        private DateTime setExpireDate(ValidUnit unit, int num)
        {
            DateTime value = DateTime.Now;
            switch (unit)
            {
                case ValidUnit.YEAR:
                    value.AddYears(num);
                    break;
                case ValidUnit.MONTH:
                    value.AddMonths(num);
                    break;
                case ValidUnit.DAY:
                    value.AddDays(num);
                    break;
                case ValidUnit.NONE:
                    break;
            }
            return value;
        }

        private void setMoneyAndNum()
        {
            MemberCardCategoryValue value = this.cmbMoney.SelectedItem as MemberCardCategoryValue;
            if (value == null)
            {
                return;
            }
            this.validTime.Value = this.setExpireDate(value.ValidUnit, value.ValueNum);
            this.txtMoney.Text = value.Money.ToString();
        }

        private void FrmRecharge_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.labMemberCardNo.Text = cardNo;
                    findCard(cardNo);
                    loadData();

                    cardNo = "";
                }
                return;
            }

            cardNo += e.KeyChar.ToString();

        }
    }
}
