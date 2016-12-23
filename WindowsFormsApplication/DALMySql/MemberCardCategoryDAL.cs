using System;
using System.Collections.Generic;
using System.Data;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    public class MemberCardCategoryDAL : IMemberCardCategoryDAL
    {
        public int save(MemberCardCategory model)
        {
            throw new System.NotImplementedException();
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(MemberCardCategory model)
        {
            throw new System.NotImplementedException();
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
    }
}