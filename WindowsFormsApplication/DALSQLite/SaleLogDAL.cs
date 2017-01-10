using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using IDAL;
using Models;
using Tools;

namespace DALSQLite
{
    public class SaleLogDAL : BaseDAL, ISaleLogDAL
    {
        public int delete(int id)
        {
            List<SQLiteParameter> parameters = new List<SQLiteParameter>()
            {
                new SQLiteParameter("@id", DbType.Int32, 11)
                {
                    Value = id
                }
            };

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "DELETE FROM sales_records WHERE id = @id;";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@id", String.Format("{0}", id));
                this.SaveQueue(sql);
            }
            return row;
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
            String sql = "SELECT * FROM sales_records WHERE " + where;
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

            SQLiteParameter[] param = this.ConvertSQLiteParameters(fillParameters(model));

            String sql = "INSERT INTO sales_records(goods_id, money, summary, created_at) VALUES (@goods_id, @money, @summary, @created_at);";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@summary", String.Format("'{0}'", model.Summary));
                sql = sql.Replace("@money", String.Format("{0}", model.Money));
                sql = sql.Replace("@goods_id", String.Format("{0}", model.GoodsId));
                sql = sql.Replace("@created_at", String.Format("{0}", model.CreatedAt));
                this.SaveQueue(sql);
            }
            return row;
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
            model.UpdatedAt = Tools.TimeStamp.GetNowTimeStamp();
            List<SQLiteParameter> parameters = fillParameters(model);
            parameters.Add(new SQLiteParameter("@goods_id", DbType.Int32, 11)
            {
                Value = model.Id
            });
            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);

            String sql = "UPDATE sales_records SET goods_id = @goods_id, money = @money, summary = @summary, updated_at = @updated_at WHERE id = @id;";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@summary", String.Format("'{0}'", model.Summary));
                sql = sql.Replace("@money", String.Format("{0}", model.Money));
                sql = sql.Replace("@goods_id", String.Format("{0}", model.GoodsId));
                sql = sql.Replace("@updated_at", String.Format("{0}", model.UpdatedAt));
                sql = sql.Replace("@id", String.Format("{0}", model.Id));
                this.SaveQueue(sql);
            }
            return row;
        }

        private List<SQLiteParameter> fillParameters(SaleLog model)
        {
            List<SQLiteParameter> param = new List<SQLiteParameter>()
            {
                new SQLiteParameter("@goods_id", DbType.Int32, 11),
                new SQLiteParameter("@money", DbType.Decimal, 11),
                new SQLiteParameter("@summary", DbType.String, 255),
                new SQLiteParameter("@created_at", DbType.Int32, 11),
                new SQLiteParameter("@updated_at", DbType.Int32, 11),
            };
            param[0].Value = model.GoodsId;
            param[1].Value = model.Money;
            param[2].Value = model.Summary;
            param[3].Value = model.CreatedAt;
            param[4].Value = model.UpdatedAt;

            return param;
        }

        private SaleLog fillSaleLog(SQLiteDataReader rdr)
        {
            SaleLog log = null;
            if (rdr.Read())
            {
                log = new SaleLog();
                log.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                log.GoodsId = rdr["goods_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["goods_id"]);
                log.Summary = rdr["summary"] == DBNull.Value ? "" : rdr["summary"].ToString();
                //log.MemberId = rdr["member_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["member_id"]);
                //log.Summary = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                //log.Remark = rdr["category_id"] == DBNull.Value ? "" : rdr["category_id"].ToString();
                //log.MemberNo = rdr["member_no"] == DBNull.Value ? "" : rdr["member_no"].ToString();
                log.Money = rdr["money"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["money"]);
                log.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt64(rdr["created_at"]);
                log.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt64(rdr["updated_at"]);

            }
            return log;
        }
    }
}