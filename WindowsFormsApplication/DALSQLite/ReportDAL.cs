using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using IDAL;
using Models;
using Tools;

namespace DALSQLite
{
    public class ReportDAL : BaseDAL, IReportDAL
    {
        public List<ReportGoodsRank> GetGoodsRank(DateTime begin, DateTime end)
        {
            List<ReportGoodsRank> ranks = null;
            String sql = String.Format("SELECT goods.category_id, gc.`name`, COUNT(*) AS count, SUM(money) AS price FROM sales_records AS sr LEFT JOIN goods ON sr.goods_id = goods.id LEFT JOIN goods_category AS gc ON gc.id = goods.category_id WHERE sr.created_at BETWEEN {0} AND {1} GROUP BY gc.id, gc.`name`", TimeStamp.ConvertDateTimeInt(begin), TimeStamp.ConvertDateTimeInt(end));
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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

        public List<ReportGoodsRank> GetStatisticsBySql(string sql)
        {
            List<ReportGoodsRank> ranks = null;
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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