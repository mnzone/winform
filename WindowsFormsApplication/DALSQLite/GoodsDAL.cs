using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DALSQLite
{
    public class GoodsDAL : BaseDAL, IGoodsDAL
    {
        public int save(Goods model)
        {
            List<SQLiteParameter> parameters = this.fillParameters(model);

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "INSERT INTO goods(name, sort, category_id, visibile, is_deleted, created_at) values(@name, @sort, @category_id, @visibile, @is_deleted, @created_at);";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@name", String.Format("'{0}'", model.Name));
                sql = sql.Replace("@category_id", String.Format("{0}", model.CategoryId));
                sql = sql.Replace("@visibile", String.Format("{0}", model.Visibile));
                sql = sql.Replace("@sort", String.Format("{0}", model.Sort));
                sql = sql.Replace("@is_deleted", String.Format("{0}", model.IsDeleted));
                sql = sql.Replace("@created_at", String.Format("{0}", model.CreatedAt));
                this.SaveQueue(sql);
            }
            return row;
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(Goods model)
        {
            throw new System.NotImplementedException();
        }

        public Goods find(int id)
        {
            Goods goods = null;
            String sql = String.Format("SELECT * FROM goods WHERE id = {0}", id);
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                goods = fillGoods(rdr);

            }

            return goods;
        }

        public List<Goods> findAll()
        {
            List<Goods> list = null;
            String sql = "SELECT * FROM goods";
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<Goods>();
                    }

                    Goods goods = fillGoods(rdr);
                    if (goods == null)
                    {
                        break;
                    }
                    list.Add(goods);
                }

            }

            return list;
        }

        public List<Goods> findByWhere(string @where)
        {
            List<Goods> list = null;
            String sql = String.Format("SELECT * FROM goods WHERE {0}", where);
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<Goods>();
                    }

                    Goods goods = fillGoods(rdr);
                    if (goods == null)
                    {
                        break;
                    }
                    list.Add(goods);
                }

            }

            return list;
        }

        public List<Goods> findByWhere(String where, DbParameter[] paramArray)
        {
            SQLiteParameter[] param = this.ConvertSQLiteParameters(paramArray);

            List<Goods> list = null;
            String sql = String.Format("SELECT * FROM goods WHERE {0} ORDER BY sort DESC, id DESC", where);
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<Goods>();
                    }

                    Goods goods = fillGoods(rdr);
                    if (goods == null)
                    {
                        break;
                    }
                    list.Add(goods);
                }

            }

            return list;
        }

        private Goods fillGoods(SQLiteDataReader rdr)
        {
            Goods goods = null;
            if (rdr.Read())
            {
                goods = new Goods();
                goods.Name = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                goods.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                goods.CategoryId = rdr["category_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["category_id"]);
                goods.Sort = rdr["sort"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["sort"]);
                goods.Visibile = rdr["visibile"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["sort"]);
                goods.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                goods.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
            }
            return goods;
        }

        private List<SQLiteParameter> fillParameters(Goods model)
        {
            List<SQLiteParameter> parameters = new List<SQLiteParameter>(){
                new SQLiteParameter("@name", DbType.String, 255),
                new SQLiteParameter("@category_id", DbType.Int32, 11),
                new SQLiteParameter("@sort", DbType.Int32, 10),
                new SQLiteParameter("@visibile", DbType.Int32, 11),
                new SQLiteParameter("@created_at", DbType.Int32, 11),
                new SQLiteParameter("@updated_at", DbType.Int32, 11),
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.CategoryId;
            parameters[2].Value = model.Sort;
            parameters[3].Value = model.Visibile;
            parameters[4].Value = model.CreatedAt;
            parameters[5].Value = model.UpdatedAt;

            return parameters;
        }
    }
}