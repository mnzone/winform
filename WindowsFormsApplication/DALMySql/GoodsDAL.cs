using IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Models;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    public class GoodsDAL : BaseDAL, IGoodsDAL
    {
        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public Goods find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Goods> findAll()
        {
            List<Goods> list = null;
            String sql = "SELECT * FROM goods";
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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
            MySqlParameter[] param = this.ConvertMySqlParameters(paramArray);
            List<Goods> list = null;
            
            String sql = String.Format("SELECT * FROM goods WHERE {0} ORDER BY sort DESC, id DESC", where);
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param))
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

        public List<Goods> findByWhere(string where)
        {
            throw new NotImplementedException();
        }

        public int save(Goods model)
        {
            System.Console.WriteLine("this is goods dal save method info.");
            return 0;
        }

        public int update(Goods model)
        {
            throw new NotImplementedException();
        }

        private Goods fillGoods(MySqlDataReader rdr)
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

        private List<MySqlParameter> fillParameters(Goods model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                new MySqlParameter("@name", MySqlDbType.String, 255),
                new MySqlParameter("@category_id", MySqlDbType.Int32, 11),
                new MySqlParameter("@sort", MySqlDbType.Int32, 10),
                new MySqlParameter("@visibile", MySqlDbType.Int32, 11),
                new MySqlParameter("@created_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@updated_at", MySqlDbType.Int32, 11),
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
