using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using IDAL;
using Models;
using System.Linq;
using Tools;

namespace DALSQLite
{
    public class MemberCardDAL : BaseDAL, IMemberCardDAL
    {
        public int save(MemberCard model)
        {
            List<SQLiteParameter> parameters = this.fillParameters(model);
            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);

            String sql = "INSERT INTO members_cards(card_no, category_id, created_at) VALUES(@card_no, @category_id, @updated_at)";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@card_no", String.Format("'{0}'", model.CardNo));
                sql = sql.Replace("@category_id", String.Format("{0}", model.CategoryId));
                sql = sql.Replace("@created_at", String.Format("{0}", model.CreatedAt));
                this.SaveQueue(sql);
            }
            return row;
        }

        public int delete(int id)
        {
            List<SQLiteParameter> parameters = new List<SQLiteParameter>()
            {
                new SQLiteParameter("@id", DbType.Int32, 11)
                {
                    Value = id
                }
            };

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "DELETE FROM members_cards WHERE id = @id;";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@id", String.Format("{0}", id));
                this.SaveQueue(sql);
            }
            return row;
        }

        public int update(MemberCard model)
        {
            List<SQLiteParameter> parameters = this.fillParameters(model);
            parameters.Add(new SQLiteParameter("@id", DbType.Int32, 11)
            {
                Value = model.Id
            });

            SQLiteParameter[] param = this.ConvertSQLiteParameters(parameters);
            String sql = "UPDATE members_cards SET card_no = @card_no, category_id = @category_id, updated_at = @updated_at WHERE id = @id;";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@card_no", String.Format("'{0}'", model.CardNo));
                sql = sql.Replace("@category_id", String.Format("{0}", model.CategoryId));
                sql = sql.Replace("@updated_at", String.Format("{0}", model.UpdatedAt));
                sql = sql.Replace("@id", String.Format("{0}", model.Id));
                this.SaveQueue(sql);

            }
            return row;
        }

        public MemberCard find(int id)
        {
            MemberCard card = null;
            String sql = String.Format("SELECT * FROM members_cards WHERE id = {0}", id);
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                card = fillMemberCard(rdr);
            }
            return card;
        }

        public MemberCard find(string no)
        {
            MemberCard card = null;
            String sql = String.Format("SELECT * FROM members_cards WHERE card_no = '{0}'", no);
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                card = fillMemberCard(rdr);
            }
            return card;
        }

        public List<MemberCard> findAll()
        {
            List<MemberCard> list = null;
            String sql = "SELECT * FROM members_cards";
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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

        private MemberCard fillMemberCard(SQLiteDataReader rdr)
        {
            MemberCard card = null;
            if (rdr.Read())
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

        private List<SQLiteParameter> fillParameters(MemberCard model)
        {
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@card_no", DbType.Int32, 11),
                new SQLiteParameter("@category_id", DbType.Int32, 10),
                new SQLiteParameter("@created_at", DbType.Int32, 11),
                new SQLiteParameter("@updated_at", DbType.Int32, 11),
            };

            parameters[0].Value = model.CardNo;
            parameters[1].Value = model.CategoryId;
            parameters[2].Value = model.CreatedAt;
            parameters[3].Value = model.UpdatedAt;

            return parameters.ToList();
        }
    }
}