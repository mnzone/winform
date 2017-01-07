using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using IDAL;
using Models;

namespace DALSQLite
{
    public class MemberCardRecordDAL : BaseDAL, IMemberCardRecordDAL
    {
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
            String sql = "DELETE FROM members_cards_records WHERE id = @id;";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param);
            if (row > 0)
            {
                sql = sql.Replace("@id", String.Format("{0}", id));
                this.SaveQueue(sql);
            }
            return row;
        }

        public MemberCardRecord find(int id)
        {
            throw new NotImplementedException();
        }

        public MemberCardRecord findByCardId(int cardId)
        {
            MemberCardRecord record = null;
            String sql = String.Format("SELECT * FROM members_cards_records WHERE member_card_id = {0} ORDER BY id DESC", cardId);
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                record = fillMemberCardRecord(rdr);
            }
            return record;
        }

        public List<MemberCardRecord> findAll()
        {
            throw new NotImplementedException();
        }

        public List<MemberCardRecord> findByWhere(string where)
        {
            List<MemberCardRecord> list = null;
            String sql = String.Format("SELECT * FROM members_cards_records WHERE {0} ORDER BY id DESC", where);
            using (SQLiteDataReader rdr = Tools.SQLiteHelper.ExecuteReader(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<MemberCardRecord>();
                    }

                    MemberCardRecord record = fillMemberCardRecord(rdr);
                    if (record == null)
                    {
                        break;
                    }
                    list.Add(record);
                }
            }
            return list;
        }

        public int save(MemberCardRecord model)
        {
            List<SQLiteParameter> param = this.fillParameters(model);
            String sql = "INSERT INTO members_cards_records(balance, begin_at, expired_at, status, member_card_id, created_at) VALUES(@balance, @begin_at, @expired_at, @status, @member_card_id, @created_at)";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param.ToArray());
            if (row > 0)
            {
                sql = sql.Replace("@balance", String.Format("{0}", model.Balance));
                sql = sql.Replace("@begin_at", String.Format("{0}", model.BeginAt));
                sql = sql.Replace("@expired_at", String.Format("{0}", model.ExpiredAt));
                sql = sql.Replace("@status", String.Format("'{0}'", model.Status.ToString()));
                sql = sql.Replace("@member_card_id", String.Format("{0}", model.MemberCardId));
                sql = sql.Replace("@created_at", String.Format("{0}", model.CreatedAt));
                this.SaveQueue(sql);
            }
            return row;
        }

        public int update(MemberCardRecord model)
        {
            List<SQLiteParameter> param = this.fillParameters(model);
            param.Add(new SQLiteParameter("@id", DbType.Int32, 11)
            {
                Value = model.Id
            });
            String sql = "UPDATE members_cards_records SET balance = @balance, begin_at = @begin_at, expired_at = @expired_at, status = @status, member_card_id = @member_card_id, updated_at = @updated_at WHERE id = @id;";
            int row = Tools.SQLiteHelper.ExecuteNonQuery(Tools.SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param.ToArray());
            if (row > 0)
            {
                sql = sql.Replace("@balance", String.Format("{0}", model.Balance));
                sql = sql.Replace("@begin_at", String.Format("{0}", model.BeginAt));
                sql = sql.Replace("@expired_at", String.Format("{0}", model.ExpiredAt));
                sql = sql.Replace("@status", String.Format("'{0}'", model.Status.ToString()));
                sql = sql.Replace("@member_card_id", String.Format("{0}", model.MemberCardId));
                sql = sql.Replace("@updated_at", String.Format("{0}", model.UpdatedAt));
                sql = sql.Replace("@id", String.Format("{0}", model.Id));
                this.SaveQueue(sql);
            }
            return row;
        }

        private MemberCardRecord fillMemberCardRecord(SQLiteDataReader rdr)
        {
            MemberCardRecord record = null;
            if (rdr.Read())
            {
                record = new MemberCardRecord();
                record.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                record.Balance = rdr["balance"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["balance"]);
                record.BeginAt = rdr["begin_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["begin_at"]);
                record.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                record.ExpiredAt = rdr["expired_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["expired_at"]);
                record.MemberCardId = rdr["member_card_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["member_card_id"]);
                record.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
                record.Status = rdr["status"] == DBNull.Value
                    ? Status.Disabled
                    : (Status)Enum.Parse(typeof(Status), rdr["status"].ToString());
            }
            return record;
        }

        private List<SQLiteParameter> fillParameters(MemberCardRecord model)
        {

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@balance", DbType.Decimal, 10),
                new SQLiteParameter("@begin_at", DbType.Int32, 11),
                new SQLiteParameter("@expired_at", DbType.Int32, 11),
                new SQLiteParameter("@member_card_id", DbType.Int32, 11),
                new SQLiteParameter("@status", DbType.String, 11),
                new SQLiteParameter("@created_at", DbType.Int32, 11),
                new SQLiteParameter("@updated_at", DbType.Int32, 11),
            };

            parameters[0].Value = model.Balance;
            parameters[1].Value = model.BeginAt;
            parameters[2].Value = model.ExpiredAt;
            parameters[3].Value = model.MemberCardId;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.CreatedAt;
            parameters[6].Value = model.UpdatedAt;

            return parameters.ToList();
        }
    }
}