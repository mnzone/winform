using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactoryImpl;
using IBLL;
using Models;
using Tools;

namespace MemberCard.Trade
{
    public partial class FrmSaleLog : FrmBase
    {
        private IReportBLL bll = null;
        private ISaleLogBLL logBll = null;
        private IGoodsBLL goodsBll = null;
        private IGoodsCategoryBLL catBll = null;

        public FrmSaleLog()
        {
            InitializeComponent();
        }

        private void FrmSaleLog_Load(object sender, EventArgs e)
        {
            BllFactory.DLLBasePath = Application.StartupPath;
            bll = BllFactory.GetReportBll();
            logBll = BllFactory.GetSaleLogBll();
            goodsBll = BllFactory.GetGoodsBll();
            catBll = BllFactory.GetGoodsCategoryBll();

            loadData();
        }

        private void loadData()
        {
            this.tsslabTotal.Text = "加载中...";
            Decimal price = 0;
            int count = 0;

            List<ReportGoodsRank> items = bll.GetStatisticsTodayCategorySale();
            foreach (ReportGoodsRank item in items)
            {
                price += item.Price;
                count += item.Count;
                this.dgvStatisticsCategory.Rows.Add(new String[]
                {
                    item.GoodsName,
                    item.Price.ToString(),
                    item.Count.ToString()
                });
            }

            this.tsslabTotal.Text = String.Format("（总金额：{0}元 总数量：{1}件）", price, count);

            items = bll.GetStatisticsTodayGoodsSale();
            foreach (ReportGoodsRank item in items)
            {
                this.dgvStatisticsGoods.Rows.Add(new String[]
                {
                    item.GoodsName,
                    item.Price.ToString(),
                    item.Count.ToString()
                });
            }

            List<SaleLog> logs = logBll.GetAllSaleLogsByDate(DateTime.Now.Date, DateTime.Now);
            foreach (SaleLog log in logs)
            {
                log.Goods = goodsBll.GetGoodsById(log.GoodsId);
                log.Goods.Category = catBll.GetCategory(log.Goods.CategoryId);
                this.dgvSaleLog.Rows.Add(new String[]
                {
                    TimeStamp.ConvertIntDateTime(log.CreatedAt).ToString("yyyy-MM-dd hh:mm:ss"),
                    log.Goods?.Name,
                    log.Goods.Category.Name,
                    log.Money.ToString(),
                    log.Summary
                });
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未开通", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
