using System;
using System.Collections.Generic;
using System.Data;
using IDAL;
using Models;
using MySql.Data.MySqlClient;
using Tools;

namespace DALMySql
{
    public class ReportDAL : BaseDAL, IReportDAL
    {
        public List<ReportGoodsRank> GetGoodsRank(DateTime begin, DateTime end)
        {
            List<ReportGoodsRank> ranks = null;
            String sql = String.Format("SELECT goods.category_id, gc.`name`, COUNT(*) AS count, SUM(money) AS price FROM sales_records AS sr LEFT JOIN goods ON sr.goods_id = goods.id LEFT JOIN goods_category AS gc ON gc.id = goods.category_id WHERE sr.created_at BETWEEN {0} AND {1} GROUP BY gc.id, gc.`name`", TimeStamp.ConvertDateTimeInt(begin), TimeStamp.ConvertDateTimeInt(end));
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                ranks = new List<ReportGoodsRank>();
                while (rdr.Read())
                {
                    ReportGoodsRank rank = new ReportGoodsRank();
                    rank.Id = rdr["category_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["category_id"]);
                    rank.GoodsName = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                    
                    rank.Count = rdr["count"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["count"]);
                    rank.Price = rdr["price"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["price"]);
                    ranks.Add(rank);
                }
                
            }

            return ranks;
        }

        /// <summary>
        /// 按年份统计数据
        /// </summary>
        /// <returns></returns>
        public List<ReportGoodsRank> GetYearStatistics(int year)
        {
            List<ReportGoodsRank> ranks = null;
            long begin = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-01-01 00:00:00", year)));
            long end = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-12-31 23:59:59", year)));
            String sql = String.Format("SELECT FROM_UNIXTIME(sale.created_at, '%Y') AS 'year', FROM_UNIXTIME(sale.created_at, '%m') AS 'month',  cat.id, cat.`name`, COUNT(*) AS count, SUM(money) AS money FROM sales_records AS sale LEFT JOIN goods AS g ON sale.goods_id = g.id LEFT JOIN goods_category AS cat ON cat.id = g.category_id WHERE sale.created_at BETWEEN {0} AND {1} GROUP BY FROM_UNIXTIME(sale.created_at, '%y'), FROM_UNIXTIME(sale.created_at, '%m'), cat.id ORDER BY FROM_UNIXTIME(sale.created_at, '%y'), FROM_UNIXTIME(sale.created_at, '%m')", begin, end);
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                ranks = new List<ReportGoodsRank>();
                while (rdr.Read())
                {
                    ReportGoodsRank rank = new ReportGoodsRank();

                    rank.Id = rdr["year"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["year"]);
                    rank.Month = rdr["month"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["month"]);
                    rank.GoodsName = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();

                    rank.Count = rdr["count"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["count"]);
                    rank.Price = rdr["money"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["money"]);
                    ranks.Add(rank);
                }

            }

            return ranks;
        }

        public List<ReportGoodsRank> GetMonthStatistics(int year, int month)
        {
            List<ReportGoodsRank> ranks = null;
            long begin = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-{1}-01 00:00:00", year, month)));
            long end = TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(String.Format("{0}-{1}-01 00:00:00", month == 12 ? year + 1 : year, month == 12 ? 1 : month + 1)));
            String sql = String.Format("SELECT FROM_UNIXTIME(sale.created_at, '%d') AS 'day', cat.id, cat.`name`, COUNT(*) AS count, SUM(money) AS money FROM sales_records AS sale LEFT JOIN goods AS g ON sale.goods_id = g.id LEFT JOIN goods_category AS cat ON cat.id = g.category_id WHERE sale.created_at BETWEEN {0} AND {1} GROUP BY FROM_UNIXTIME(sale.created_at, '%d'), cat.id ORDER BY FROM_UNIXTIME(sale.created_at, '%d')", begin, end);
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                ranks = new List<ReportGoodsRank>();
                while (rdr.Read())
                {
                    ReportGoodsRank rank = new ReportGoodsRank();
                    
                    rank.Month = rdr["day"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["day"]);
                    rank.GoodsName = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();

                    rank.Count = rdr["count"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["count"]);
                    rank.Price = rdr["money"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["money"]);
                    ranks.Add(rank);
                }

            }

            return ranks;
        }
    }
}