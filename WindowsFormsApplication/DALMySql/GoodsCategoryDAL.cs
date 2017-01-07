using System;
using System.Collections.Generic;
using System.Data;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    public class GoodsCategoryDAL : BaseDAL, IGoodsCategoryDAL
    {
        public int save(GoodsCategory model)
        {
            throw new System.NotImplementedException();
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(GoodsCategory model)
        {
            throw new System.NotImplementedException();
        }

        public GoodsCategory find(int id)
        {
            GoodsCategory category = null;
            String sql = String.Format("SELECT * FROM goods_categories WHERE id = {0}", id);
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                category = fillGoodsCategory(rdr);
            }

            return category;
        }

        public List<GoodsCategory> findAll()
        {
            List<GoodsCategory> list = null;
            String sql = "SELECT * FROM goods_categories";
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<GoodsCategory>();
                    }

                    GoodsCategory category = fillGoodsCategory(rdr);
                    if (category == null)
                    {
                        break;
                    }
                    list.Add(category);
                }

            }

            return list;
        }

        public List<GoodsCategory> findByWhere(string @where)
        {
            List<GoodsCategory> list = null;
            String sql = String.Format("SELECT * FROM goods_categories WHERE {0} ORDER BY id DESC", where);
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<GoodsCategory>();
                    }

                    GoodsCategory category = fillGoodsCategory(rdr);
                    if (category == null)
                    {
                        break;
                    }
                    list.Add(category);
                }

            }

            return list;
        }

        private GoodsCategory fillGoodsCategory(MySqlDataReader rdr)
        {
            GoodsCategory category = null;
            if (rdr.Read())
            {
                category = new GoodsCategory();
                category.Name = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                category.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                category.ParentId = rdr["parent_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["parent_id"]);
                category.Sort = rdr["sort"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["sort"]);
                category.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                category.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
            }
            return category;
        }
    }
}