using System;
using System.Drawing;
using System.Windows.Forms;
using DelegateLibrary;
using Models;
using System.Configuration;
using FactoryImpl;
using Tools;
using IBLL;

namespace GoodsManager.Trade
{
    public partial class FrmSale : Form
    {

        private CallbackMsg callback;
        private Goods goods;

        public FrmSale()
        {
            InitializeComponent();
            BllFactory.DLLBasePath = Application.StartupPath;
        }

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

        public Goods Goods
        {
            get
            {
                return goods;
            }

            set
            {
                goods = value;
            }
        }

        private void FrmSale_Load(object sender, System.EventArgs e)
        {
            String fontFamilyName = ConfigurationManager.AppSettings["FontFamilyName"];
            Font labelFont = new Font(fontFamilyName, float.Parse(ConfigurationManager.AppSettings["LabelFontSize"]));
            Font textFont = new Font(fontFamilyName, float.Parse(ConfigurationManager.AppSettings["TextFontSize"]));
            Font buttonFont = new Font(fontFamilyName, float.Parse(ConfigurationManager.AppSettings["ButtonFontSize"]));
            
            
            //设置按钮字体
            this.btnClose.Font = buttonFont;
            this.btnSubmit.Font = buttonFont;

            //调整按钮位置调整
            int top = Convert.ToInt32((this.btnSubmit.Parent.Height - this.btnSubmit.Height) / 2);
            int left = (this.btnSubmit.Parent.Width/2 - this.btnSubmit.Width) / 2;
            
            this.btnSubmit.Height = buttonFont.Height + 10;
            this.btnSubmit.Left = left;
            this.btnSubmit.Top = top;

            top = Convert.ToInt32((this.btnClose.Parent.Height - this.btnClose.Height) / 2);
            left = this.btnClose.Parent.Width / 2 + (this.btnClose.Parent.Width / 2 - this.btnClose.Width) / 2;

            this.btnClose.Height = buttonFont.Height + 10;
            this.btnClose.Left = left;
            this.btnClose.Top = top;


            this.labGoodsName.Font = labelFont;
            this.labGoodsName.Text = this.goods == null ? "" : this.goods.Name;
            //销售价格位置调整
            top = Convert.ToInt32((this.labGoodsName.Parent.Height - this.labGoodsName.Height) / 2);
            left = Convert.ToInt32((this.labGoodsName.Parent.Width - this.labGoodsName.Width) / 2);
            this.labGoodsName.Top = top;
            this.labGoodsName.Left = left;

            this.txtFee.Font = textFont;
            //销售价格位置调整
            top = Convert.ToInt32((this.txtFee.Parent.Height - this.txtFee.Height) / 2);
            left = Convert.ToInt32((this.txtFee.Parent.Width - this.txtFee.Width) / 2);
            this.txtFee.Top = top;
            this.txtFee.Left = left;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtFee.Text.Trim()))
            {
                MessageBox.Show("请填写销售金额!", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaleLog log = new SaleLog();
            log.CreatedAt = TimeStamp.GetNowTimeStamp();
            log.Money = Convert.ToDecimal(this.txtFee.Text.Trim());
            log.GoodsId = this.goods.Id;
            log.MemberNo = "";
            log.Summary = String.Format("{0}出售了{1}元的{2}", 
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
                this.txtFee.Text.Trim(), 
                this.goods.Name);

            ISaleLogBLL logBll = BllFactory.GetSaleLogBll();
            if ( ! logBll.AddLog(log))
            {
                MessageBox.Show("商品销售记录失败!", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            callback(log.Summary);
            this.Close();
        }
    }
}

