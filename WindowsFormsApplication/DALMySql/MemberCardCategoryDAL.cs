using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    public class MemberCardCategoryDAL : BaseDAL, IMemberCardCategoryDAL
    {
        public int save(MemberCardCategory model)
        {
            List<MySqlParameter> parameters = this.fillParameters(model);
            parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 11)
            {
                Value = model.Id
            });

            MySqlParameter[] param = this.ConvertMySqlParameters(parameters);
            String sql = "INSERT INTO members_cards(card_no, category_id, created_at) values(@card_no, @category_id, @created_at);";
            return Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(MemberCardCategory model)
        {
            List<MySqlParameter> parameters = this.fillParameters(model);
            parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 11)
            {
                Value = model.Id
            });

            MySqlParameter[] param = this.ConvertMySqlParameters(parameters);
            String sql = "UPDATE members_cards SET card_no = @card_no, category_id = @category_id, updated_at = @updated_at WHERE id = @id;";
            return Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
        }

        public MemberCardCategory find(int id)
        {
            MemberCardCategory category = null;
            String sql = String.Format("SELECT * FROM members_cards_categories WHERE id = {0}", id);

            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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

        private MemberCardCategory fillMemberCardCategory(MySqlDataReader rdr)
        {
            MemberCardCategory category = null;
            if (rdr.Read())
            {
                category = new MemberCardCategory();
                category.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                category.Name = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                category.BeginAt = rdr["begin_at"] == DBNull.Value ? "" : rdr["begin_at"].ToString();
                category.EndAt = rdr["end_at"] == DBNull.Value ? "" : rdr["end_at"].ToString();
                category.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                category.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
            }
            return category;
        }

        private List<MySqlParameter> fillParameters(MemberCardCategory model)
        {
            MySqlParameter[] parameters = {
                new MySqlParameter("@name", MySqlDbType.VarChar, 11),
                new MySqlParameter("@begin_at", MySqlDbType.String, 10),
                new MySqlParameter("@end_at", MySqlDbType.String, 11),
                new MySqlParameter("@created_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@updated_at", MySqlDbType.Int32, 11),
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