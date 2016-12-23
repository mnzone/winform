using System;
using System.Collections.Generic;
using System.Data;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    public class SaleLogDAL : ISaleLogDAL
    {
        public int save(SaleLog model)
        {
            model.CreatedAt = Tools.TimeStamp.ConvertDateTimeInt(DateTime.Now);
            MySqlParameter[] param = this.fillParameters(model);
            String sql = "INSERT INTO sales_records(goods_id, money, summary, created_at, updated_at) VALUES(@goods_id, @money, @summary, @created_at, @updated_at);";
            return Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
        }

        public int save(List<SaleLog> model)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            String sql = String.Format("DELETE FROM sales_records WHERE id = {0}", id);
            int result = Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql);
            return result;
        }

        public int update(SaleLog model)
        {
            model.UpdatedAt = Tools.TimeStamp.ConvertDateTimeInt(DateTime.Now);
            MySqlParameter[] param = this.fillParameters(model);
            param[param.Length] = new MySqlParameter("@id", MySqlDbType.Int32, 11);

            String sql = "UPDATE sales_records SET goods_id = @goods_id, money = @money, summary = @summary, created_at = @created_at, updated_at = @updated_at SET id = @id;";
            return Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
        }

        public SaleLog find(int id)
        {
            String sql = String.Format("SELECT * FROM sales_records WHERE id = {0}", id);
            SaleLog log = null;
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                log = this.fillSaleLog(rdr);
            }
            return log;
        }

        public List<SaleLog> findAll()
        {
            String sql = "SELECT * FROM sales_records ORDER BY id DESC";
            return findBySql(sql);
        }

        public List<SaleLog> findByWhere(string @where)
        {
            String sql = String.Format("SELECT * FROM sales_records WHERE {0} ORDER BY id DESC", where);
            return findBySql(sql);
        }

        private List<SaleLog> findBySql(String sql)
        {
            List<SaleLog> logs = null;
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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

        private SaleLog fillSaleLog(MySqlDataReader rdr)
        {
            SaleLog category = null;
            if (rdr.Read())
            {
                category = new SaleLog();
                category.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                category.GoodsId = rdr["goods_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["goods_id"]);
                category.Summary = rdr["summary"] == DBNull.Value ? "" : rdr["summary"].ToString();
                category.Money = rdr["money"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["money"]);
                category.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                category.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
            }
            return category;
        }

        private MySqlParameter[] fillParameters(SaleLog model)
        {
            MySqlParameter[] parameters = {
                new MySqlParameter("@goods_id", MySqlDbType.Int32, 11),
                new MySqlParameter("@money", MySqlDbType.Decimal, 10),
                new MySqlParameter("@summary", MySqlDbType.VarChar, 1000),
                new MySqlParameter("@created_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@updated_at", MySqlDbType.Int32, 11),
            };

            parameters[0].Value = model.GoodsId;
            parameters[1].Value = model.Money;
            parameters[2].Value = model.Summary;
            parameters[3].Value = model.CreatedAt;
            parameters[4].Value = model.UpdatedAt;

            return parameters;
        }
    }
}