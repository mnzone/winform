using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using IDAL;
using Models;

namespace DALSQLite
{
    public class MemberCardCategoryDAL : BaseDAL, IMemberCardCategoryDAL
    {
        public int save(MemberCardCategory model)
        {
            List<SQLiteParameter> parameters = this.fillParameters(model);

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "INSERT INTO members_cards_categories(name, begin_at, end_at, not_allow, created_at) values(@name, @begin_at, @end_at, @not_allow, @created_at);";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@name", String.Format("'{0}'", model.Name));
                sql = sql.Replace("@begin_at", String.Format("{0}", model.BeginAt));
                sql = sql.Replace("@end_at", String.Format("{0}", model.EndAt));
                sql = sql.Replace("@not_allow", String.Format("'{0}'", model.Name));
                sql = sql.Replace("@created_at", String.Format("{0}", model.CreatedAt));
                this.SaveQueue(sql);
            }
            return row;
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(MemberCardCategory model)
        {
            List<SQLiteParameter> parameters = this.fillParameters(model);
            parameters.Add(new SQLiteParameter("@id", DbType.Int32, 11)
            {
                Value = model.Id
            });

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "UPDATE members_cards_categories SET name = @name, begin_at = @begin_at, end_at = @end_at, not_allow = @not_allow, updated_at = @updated_at WHERE id = @id;";
            return Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
        }

        public MemberCardCategory find(int id)
        {
            MemberCardCategory category = null;
            String sql = String.Format("SELECT * FROM members_cards_categories WHERE id = {0}", id);

            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                category = fillMemberCardCategory(rdr);
            }
            return category;
        }

        public List<MemberCardCategory> findAll()
        {
            throw new System.NotImplementedException();
        }

        public List<MemberCardCategory> findByWhere(string @where)
        {
            throw new System.NotImplementedException();
        }

        public List<MemberCardCategory> findByWhere(string @where, DbParameter[] whereParameters)
        {
            throw new NotImplementedException();
        }

        private MemberCardCategory fillMemberCardCategory(SQLiteDataReader rdr)
        {
            MemberCardCategory category = null;
            if (rdr.Read())
            {
                category = new MemberCardCategory();
                category.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                category.Name = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                category.BeginAt = rdr["begin_at"] == DBNull.Value ? "" : rdr["begin_at"].ToString();
                category.EndAt = rdr["end_at"] == DBNull.Value ? "" : rdr["end_at"].ToString();
                category.NotAllow = rdr["not_allow"] == DBNull.Value ? "" : rdr["not_allow"].ToString();
                category.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                category.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
            }
            return category;
        }

        private List<SQLiteParameter> fillParameters(MemberCardCategory model)
        {
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@name", DbType.String, 11),
                new SQLiteParameter("@begin_at", DbType.String, 10),
                new SQLiteParameter("@end_at", DbType.String, 11),
                new SQLiteParameter("@created_at", DbType.Int32, 11),
                new SQLiteParameter("@updated_at", DbType.Int32, 11),
                new SQLiteParameter("@not_allow", DbType.String, 1000),
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.BeginAt;
            parameters[2].Value = model.EndAt;
            parameters[3].Value = model.CreatedAt;
            parameters[4].Value = model.UpdatedAt;

            return parameters.ToList();
        }
    }
}