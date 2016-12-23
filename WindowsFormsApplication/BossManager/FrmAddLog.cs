using System;
using System.Windows.Forms;
using IBLL;
using Models;

namespace BossManager
{
    public partial class FrmAddLog : Form
    {
        private ISaleLogBLL bll = null;

        public FrmAddLog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String msg = null;
            if (String.IsNullOrEmpty(this.txtPrice.Text.Trim()))
            {
                msg = "请填写交易金额";
            }else if (this.txtGoods.Tag == null)
            {
                msg = "请选择商品信息";
            }
            else if (String.IsNullOrEmpty(this.txtSummary.Text.Trim()))
            {
                msg = "请填写交易描述";
            }

            if (msg != null)
            {
                MessageBox.Show(msg, "数据不完整", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Models.SaleLog log = new SaleLog();
            log.CreatedAt = Tools.TimeStamp.ConvertDateTimeInt(DateTime.Now);
            log.GoodsId = (this.txtGoods.Tag as Goods).Id;
            log.Money = Convert.ToDecimal(this.txtPrice.Text.Trim());
            log.Summary = this.txtSummary.Text.Trim();

            bll.AddLog(log);
        }
    }
}
