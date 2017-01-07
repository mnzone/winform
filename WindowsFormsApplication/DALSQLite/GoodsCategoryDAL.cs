using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using IDAL;
using Models;

namespace DALSQLite
{
    public class GoodsCategoryDAL : BaseDAL, IGoodsCategoryDAL
    {
        public int save(GoodsCategory model)
        {
            List<SQLiteParameter> parameters = this.fillParameters(model);

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "INSERT INTO goods_categories(name, parent_id, sort, created_at) values(@name, @parent_id, @sort, @created_at);";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@name", String.Format("'{0}'", model.Name));
                sql = sql.Replace("@parent_id", String.Format("{0}", model.ParentId));
                sql = sql.Replace("@sort", String.Format("{0}", model.Sort));
                sql = sql.Replace("@created_at", String.Format("{0}", model.CreatedAt));
                this.SaveQueue(sql);
            }
            return row;
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(GoodsCategory model)
        {
            List<SQLiteParameter> parameters = this.fillParameters(model);

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "UPDATE goods_categories SET name = @name, parent_id = @parent_id, sort = @sort, updated_at = @updated_at WHERE id = @id;";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@name", String.Format("'{0}'", model.Name));
                sql = sql.Replace("@parent_id", String.Format("{0}", model.ParentId));
                sql = sql.Replace("@sort", String.Format("{0}", model.Sort));
                sql = sql.Replace("@updated_at", String.Format("{0}", model.UpdatedAt));
                this.SaveQueue(sql);
            }
            return row;
        }

        public GoodsCategory find(int id)
        {
            GoodsCategory category = null;
            String sql = String.Format("SELECT * FROM goods_categories WHERE id = {0}", id);
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                category = fillGoodsCategory(rdr);
            }

            return category;
        }

        public List<GoodsCategory> findAll()
        {
            List<GoodsCategory> list = null;
            String sql = "SELECT * FROM goods_categories";
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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

        private GoodsCategory fillGoodsCategory(SQLiteDataReader rdr)
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

        private List<SQLiteParameter> fillParameters(GoodsCategory model)
        {
            List<SQLiteParameter> parameters = new List<SQLiteParameter>(){
                new SQLiteParameter("@name", DbType.String, 255),
                new SQLiteParameter("@parent_id", DbType.Int32, 11),
                new SQLiteParameter("@sort", DbType.Int32, 10),
                new SQLiteParameter("@created_at", DbType.Int32, 11),
                new SQLiteParameter("@updated_at", DbType.Int32, 11),
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.Sort;
            parameters[3].Value = model.CreatedAt;
            parameters[4].Value = model.UpdatedAt;

            return parameters;
        }
    }
}