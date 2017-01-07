using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    class MemberCardRecordDAL : BaseDAL, IMemberCardRecordDAL
    {
        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public MemberCardRecord find(int id)
        {
            throw new NotImplementedException();
        }

        public MemberCardRecord findByCardId(int cardId)
        {
            MemberCardRecord record = null;
            String sql = String.Format("SELECT * FROM members_cards_records WHERE member_card_id = {0} ORDER BY id DESC", cardId);
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
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
            throw new NotImplementedException();
        }

        public int update(MemberCardRecord model)
        {
            List<MySqlParameter> param = this.fillParameters(model);
            param.Add(new MySqlParameter("@id", MySqlDbType.Int32, 11)
            {
                Value = model.Id
            });
            String sql = "UPDATE members_cards_records SET balance = @balance, begin_at = @begin_at, expired_at = @expired_at, status = @status, member_card_id = @member_card_id, updated_at = @updated_at WHERE id = @id;";
            return Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, param.ToArray());
        }

        private MemberCardRecord fillMemberCardRecord(MySqlDataReader rdr)
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
                    : (Status) Enum.Parse(typeof(Status), rdr["status"].ToString());
            }
            return record;
        }

        private List<MySqlParameter> fillParameters(MemberCardRecord model)
        {

            MySqlParameter[] parameters = {
                new MySqlParameter("@balance", MySqlDbType.Decimal, 10),
                new MySqlParameter("@begin_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@expired_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@member_card_id", MySqlDbType.Int32, 11),
                new MySqlParameter("@status", MySqlDbType.Enum, 11),
                new MySqlParameter("@created_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@updated_at", MySqlDbType.Int32, 11),
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