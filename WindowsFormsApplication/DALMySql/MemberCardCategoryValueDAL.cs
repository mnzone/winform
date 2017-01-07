using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    public class MemberCardCategoryValueDAL : BaseDAL, IMemberCardCategoryValueDAL
    {
        public int save(Models.MemberCardCategoryValue model)
        {
            throw new System.NotImplementedException();
        }

        public int delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int update(Models.MemberCardCategoryValue model)
        {
            throw new System.NotImplementedException();
        }

        public Models.MemberCardCategoryValue find(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Models.MemberCardCategoryValue> findAll()
        {
            String sql = "SELECT * FROM members_cards_categories_values";
            return this.query(sql);
        }

        public List<Models.MemberCardCategoryValue> findByWhere(string @where)
        {
            String sql = String.Format("SELECT * FROM members_cards_categories_values WHERE {0}", where);
            return this.query(sql);
        }

        private List<MemberCardCategoryValue> query(String sql)
        {
            List<MemberCardCategoryValue> list = null;
            using (MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (true)
                {
                    if (list == null)
                    {
                        list = new List<MemberCardCategoryValue>();
                    }

                    MemberCardCategoryValue category = fillObject(rdr);
                    if (category == null)
                    {
                        break;
                    }
                    list.Add(category);
                }

            }

            return list;
        }

        private MemberCardCategoryValue fillObject(MySqlDataReader rdr)
        {
            MemberCardCategoryValue value = null;
            if (rdr.Read())
            {
                value = new MemberCardCategoryValue();
                value.Title = rdr["title"] == DBNull.Value ? "" : rdr["title"].ToString();
                value.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                value.MemberCardCategoryId = rdr["member_card_category_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["member_card_category_id"]);
                value.Money = rdr["money"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["money"]);
                value.VaildValue = rdr["vaild_value"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["vaild_value"]);
                value.ValueNum = rdr["value_num"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["value_num"]);
                value.ValidUnit = rdr["vaild_unit"] == DBNull.Value
                    ? 0
                    : (ValidUnit) Enum.Parse(typeof(ValidUnit), rdr["vaild_unit"].ToString(), false);
                value.GoodsId = rdr["goods_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["goods_id"]);
                value.CreatedAt = rdr["created_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["created_at"]);
                value.UpdatedAt = rdr["updated_at"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["updated_at"]);
            }
            return value;
        }

        private List<MySqlParameter> fillParameters(MemberCardCategoryValue model)
        {
            MySqlParameter[] parameters = {
                new MySqlParameter("@title", MySqlDbType.Int32, 11),
                new MySqlParameter("@member_card_category_id", MySqlDbType.Int32, 10),
                new MySqlParameter("@money", MySqlDbType.Decimal, 11),
                new MySqlParameter("@vaild_value", MySqlDbType.Int32, 11),
                new MySqlParameter("@value_num", MySqlDbType.Int32, 11),
                new MySqlParameter("@vaild_unit", MySqlDbType.String, 11),
                new MySqlParameter("@goods_id", MySqlDbType.Int32, 11),
                new MySqlParameter("@created_at", MySqlDbType.Int32, 11),
                new MySqlParameter("@updated_at", MySqlDbType.Int32, 11),
            };

            parameters[0].Value = model.Title;
            parameters[1].Value = model.MemberCardCategoryId;
            parameters[2].Value = model.Money;
            parameters[3].Value = model.VaildValue;
            parameters[4].Value = model.ValueNum;
            parameters[5].Value = model.ValidUnit;
            parameters[6].Value = model.GoodsId;
            parameters[7].Value = model.CreatedAt;
            parameters[8].Value = model.UpdatedAt;

            return parameters.ToList();
        }
    }
}