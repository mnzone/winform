using System.Collections.Generic;
using FactoryImpl;
using System.Windows.Forms;
using IBLL;
using Models;
using MemberCard = Models.MemberCard;

namespace MemberCard.Trade
{
    public partial class FrmRecharge : Form
    {
        private Models.MemberCard card;
        private IMemberCardRecordBLL recordBll = null;
        private IMemberCardCategoryBLL catBll = null;
        private IMemberCardBLL cardBll = null;
        private IMemberCardCategoryValueBLL catValueBll = null;

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
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {

        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.card = cardBll.GetMemberCardByNo(this.txtKeyword.Text.Trim());
                loadData();
            }
        }

        private void FrmRecharge_Load(object sender, System.EventArgs e)
        {
            this.initBll();

            this.loadData();
            this.txtKeyword.Text = this.card == null ? "" : this.card.CardNo;
            //加载会员卡充值列表
            
        }

        private void loadData()
        {
            if (this.card == null)
            {
                return;
            }
            List<MemberCardCategoryValue> items = catValueBll.GetAllMemberCardCategoryValuesByCategoryId(this.card.CategoryId);
            this.cmbMoney.DisplayMember = "Money";
            this.cmbMoney.DataSource = items;
        }
    }
}
