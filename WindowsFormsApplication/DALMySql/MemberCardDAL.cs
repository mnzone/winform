using System;
using System.Collections.Generic;
using System.Data;
using Models;
using MySql.Data.MySqlClient;
using MySqlHelper = Tools.MySqlHelper;

namespace DALMySql
{
    public class MemberCardDAL : IDAL.IMemberCardDAL
    {
        public int save(MemberCard model)
        {
            throw new System.NotImplementedException();
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(MemberCard model)
        {
            MySqlParameter[] param = this.fillParameters(model);
            String sql = "UPDATE members_cards SET card_no = @card_no, category_id = @category_id, updated_at = @updated_at WHERE id = @id;";
            return Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
        }

        public MemberCard find(int id)
        {
            MemberCard card = null;
            String sql = String.Format("SELECT * FROM members_cards WHERE id = {0}", id);
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                card = fillMemberCard(rdr);
            }
            return card;
        }

        public MemberCard find(string no)
        {
            MemberCard card = null;
            String sql = String.Format("SELECT * FROM members_cards WHERE card_no = '{0}'", no);
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                card = fillMemberCard(rdr);
            }
            return card;
        }

        public List<MemberCard> findAll()
        {
            List<MemberCard> list = null;
            String sql = "SELECT * FROM members_cards";
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<MemberCard>();
                    }

                    MemberCard card = fillMemberCard(rdr);
                    if (card == null)
                    {
                        break;
                    }
                    list.Add(card);
                }

            }

            return list;
        }

        public List<MemberCard> findByWhere(string @where)
        {
            throw new System.NotImplementedException();
        }

        private MemberCard fillMemberCard(MySqlDataReader rdr)
        {
            MemberCard card = null;
            if(rdr.Read())
            {
                card = new MemberCard();
                card.CardNo = rdr["card_no"] == DBNull.Value ? "" : rdr["card_no"].ToString();
                card.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                card.CategoryId = rdr["category_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["category_id"]);
                card.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                card.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
            }
            return card;
        }

        private MySqlParameter[] fillParameters(MemberCard model)
        {
            MySqlParameter[] parameters = {
                new MySqlParameter("@card_no", MySqlDbType.Int32, 11),
                new MySqlParameter("@category_id", MySqlDbType.Decimal, 10),
                new MySqlParameter("@created_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@updated_at", MySqlDbType.Int32, 11),
            };

            parameters[0].Value = model.CardNo;
            parameters[1].Value = model.CategoryId;
            parameters[2].Value = model.CreatedAt;
            parameters[3].Value = model.UpdatedAt;

            return parameters;
        }
    }
}