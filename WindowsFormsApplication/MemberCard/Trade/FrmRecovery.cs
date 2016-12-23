using System;
using System.Windows.Forms;

namespace MemberCard.Trade
{
    public partial class FrmRecovery : Form
    {
        Models.MemberCard card = null;

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

        }

        private void FrmRecovery_Load(object sender, EventArgs e)
        {
            if (this.card == null)
            {
                return;
            }

            
            this.labNo.Text = this.card.CardNo.Trim();
            this.labBalance.Text = this.card.Record.Balance.ToString();
            this.labCategory.Text = this.card.Category.Name.Trim();
            this.labExpirt.Text = this.card.Record.ExpiredAt.ToString();
        }
    }
}
