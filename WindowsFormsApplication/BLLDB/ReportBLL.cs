using System;
using System.Collections.Generic;
using IBLL;
using IDAL;
using Models;
using Tools;

namespace BLLDB
{
    public class ReportBLL : IReportBLL
    {
        private IReportDAL dal = null;

        public ReportBLL() { }

        public ReportBLL(Object startupPath)
        {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateReportInstance();
        }

        public List<ReportGoodsRank> SaleGoodsRank(int day)
        {
            DateTime begin = DateTime.Now.AddDays(- day);
            DateTime end = DateTime.Now;

            return dal.GetGoodsRank(begin, end);
        }

        public List<ReportGoodsRank> SaleGoodsRankByAll()
        {
            DateTime begin = Convert.ToDateTime("2014-01-01");
            DateTime end = DateTime.Now;

            return dal.GetGoodsRank(begin, end);
        }

        public List<ReportGoodsRank> GroupStatisticsByYear(int year)
        {
            long begin = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-01-01 00:00:00", year)));
            long end = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-12-31 23:59:59", year)));
            String sql = String.Format("SELECT FROM_UNIXTIME(sale.created_at, '%Y') AS 'year', FROM_UNIXTIME(sale.created_at, '%m') AS 'month', cat.`name`, COUNT(*) AS count, SUM(money) AS money FROM sales_records AS sale LEFT JOIN goods AS g ON sale.goods_id = g.id LEFT JOIN goods_categories AS cat ON cat.id = g.category_id WHERE sale.created_at BETWEEN {0} AND {1} GROUP BY FROM_UNIXTIME(sale.created_at, '%y'), FROM_UNIXTIME(sale.created_at, '%m'), cat.id ORDER BY FROM_UNIXTIME(sale.created_at, '%y'), FROM_UNIXTIME(sale.created_at, '%m')", begin, end);

            return dal.GetStatisticsBySql(sql);
        }

        public List<ReportGoodsRank> GroupStatisticsByDay(int year, int month)
        {
            long begin = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-{1}-01 00:00:00", year, month)));
            long end = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-{1}-01 00:00:00", month == 12 ? year + 1 : year, month == 12 ? 1 : month + 1)));
            String sql = String.Format("SELECT FROM_UNIXTIME(sale.created_at, '%d') AS 'day', cat.id, cat.`name`, COUNT(*) AS count, SUM(money) AS money FROM sales_records AS sale LEFT JOIN goods AS g ON sale.goods_id = g.id LEFT JOIN goods_categories AS cat ON cat.id = g.category_id WHERE sale.created_at BETWEEN {0} AND {1} GROUP BY FROM_UNIXTIME(sale.created_at, '%d'), cat.id ORDER BY FROM_UNIXTIME(sale.created_at, '%d')", begin, end);

            return dal.GetStatisticsBySql(sql);
        }

        public List<ReportGoodsRank> GetStatisticsByCategory(int catId, long beginAt, long endAt)
        {
            String sql = String.Format("SELECT g.name, SUM(money) AS money, COUNT(*) AS count FROM sales_records AS s LEFT JOIN goods AS g ON s.goods_id = g.id WHERE g.category_id = {0} AND s.created_at BETWEEN {1} AND {2} GROUP BY  g.name", catId, beginAt, endAt);

            return dal.GetStatisticsBySql(sql);
        }
    }
}