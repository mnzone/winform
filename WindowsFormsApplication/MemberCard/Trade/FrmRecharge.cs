using System.Windows.Forms;

namespace MemberCard.Trade
{
    public partial class FrmRecharge : Form
    {
        private Models.MemberCard card;

        public FrmRecharge()
        {
            InitializeComponent();
        }
        public FrmRecharge(Models.MemberCard card) : this()
        {
            this.card = card;
        }
    }
}
