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

        public List<Goods> findByWhere(DbParameter[] paramArray)
        {
            MySqlParameter[] param = this.ConvertMySqlParameters(paramArray);
            List<Goods> list = null;

            String where = "";
            foreach (MySqlParameter item in param)
            {
                where += String.Format("{0} = {1} AND ", item.ParameterName.Replace("@", ""), item.ParameterName);
            }

            where = where.Substring(0, where.Length - 4);
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
    }
}
