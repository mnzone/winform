using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using IDAL;
using Models;
using MySql.Data.MySqlClient;
using Tools;

namespace DALSQLite
{
    public class SaleLogDAL : ISaleLogDAL
    {
        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public SaleLog find(int id)
        {
            throw new NotImplementedException();
        }

        public List<SaleLog> findAll()
        {
            
            throw new NotImplementedException();
        }

        public List<SaleLog> findByWhere(string where)
        {
            String sql = "SELECT * FROM sales_record WHERE " + where;
            sql += " order by id";

            List<SaleLog> logs = null;
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                logs = new List<SaleLog>();
                while (true)
                {
                    SaleLog log = this.fillSaleLog(rdr);
                    if (log == null)
                    {
                        break;
                    }
                    logs.Add(log);
                }
            }
            return logs;
        }

        public int save(SaleLog model)
        {
            model.CreatedAt = Tools.TimeStamp.GetNowTimeStamp();

            MySqlParameter[] param = new MySqlParameter[]
            {
                new MySqlParameter("@goods_id", MySqlDbType.Int32, 11),
                new MySqlParameter("@money", MySqlDbType.Decimal, 11),
                new MySqlParameter("@summary", MySqlDbType.VarChar, 255),
                new MySqlParameter("@created_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@updated_at", MySqlDbType.Int32, 11),
            };
            param[0].Value = model.GoodsId;
            param[1].Value = model.Money;
            param[2].Value = model.Summary;
            param[3].Value = model.CreatedAt;
            param[4].Value = model.UpdatedAt;

            String sql = "INSERT INTO sales_records(goods_id, money, summary, created_at, updated_at) VALUES (@goods_id, @money, @summary, @created_at, @updated_at);";
            return Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
        }

        public int save(List<SaleLog> list)
        {
            int result = 0;
            int count = 0;
            String sql = "INSERT INTO sales_records(goods_id, money, summary, created_at, updated_at) VALUES ";
            foreach (SaleLog model in list)
            {
                sql += String.Format("({0}, {1}, '{2}', {3}, {4}),",
                        model.GoodsId, model.Money, model.Summary, model.CreatedAt, model.UpdatedAt);

                count++;
                if (count > 10000)
                {
                    sql = sql.Substring(0, sql.Length - 1);
                    result += Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql);
                    sql = "INSERT INTO sales_records(goods_id, money, summary, created_at, updated_at) VALUES ";
                    count = 0;
                }
            }

            if (count > 0)
            {
                sql = sql.Substring(0, sql.Length - 1);
                result += Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql);
            }
            
            return result;
        }

        public int update(SaleLog model)
        {
            throw new NotImplementedException();
        }

        private SaleLog fillSaleLog(SQLiteDataReader rdr)
        {
            SaleLog log = null;
            if (rdr.Read())
            {
                log = new SaleLog();
                log.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                log.GoodsId = rdr["goods_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["goods_id"]);
                log.MemberId = rdr["member_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["member_id"]);
                log.Summary = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                log.Remark = rdr["category_id"] == DBNull.Value ? "" : rdr["category_id"].ToString();
                log.MemberNo = rdr["member_no"] == DBNull.Value ? "" : rdr["member_no"].ToString();
                log.Money = rdr["money"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["money"]);
                log.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Tools.TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(rdr["created_at"]));
                //log.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);

            }
            return log;
        }
    }
}