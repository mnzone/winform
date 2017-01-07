using Newtonsoft.Json.Linq;
using System;

namespace Models
{
    public class MemberCardCategoryValue : BaseModel
    {
        private int id;
        private int memberCardCategoryId;
        private String title;
        private Decimal money;
        private int valueNum;
        private int vaildValue;
        private int goodsId;
        private ValidUnit validUnit;
        private int createdAt;
        private int updatedAt;

        public MemberCardCategoryValue() { }

        public MemberCardCategoryValue(JObject json) {
            this.id = Convert.ToInt32(json["id"]);
            this.memberCardCategoryId = Convert.ToInt32(json["member_card_caategory_id"]);
            this.title = json["title"].ToString();
            this.money = Convert.ToDecimal(json["money"].ToString());
            this.valueNum = Convert.ToInt32(json["value_num"].ToString());
            this.vaildValue = Convert.ToInt32(json["valid_value"].ToString());
            this.validUnit = (ValidUnit)ValidUnit.Parse(typeof(ValidUnit), json["valid_unit"].ToString());
            this.createdAt = Convert.ToInt32(json["created_at"].ToString());
            this.updatedAt = Convert.ToInt32(json["updated_at"].ToString());
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int MemberCardCategoryId
        {
            get
            {
                return memberCardCategoryId;
            }

            set
            {
                memberCardCategoryId = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public int ValueNum
        {
            get
            {
                return valueNum;
            }

            set
            {
                valueNum = value;
            }
        }

        public int VaildValue
        {
            get
            {
                return vaildValue;
            }

            set
            {
                vaildValue = value;
            }
        }

        public ValidUnit ValidUnit
        {
            get
            {
                return validUnit;
            }

            set
            {
                validUnit = value;
            }
        }

        public int CreatedAt
        {
            get
            {
                return createdAt;
            }

            set
            {
                createdAt = value;
            }
        }

        public int UpdatedAt
        {
            get
            {
                return updatedAt;
            }

            set
            {
                updatedAt = value;
            }
        }

        public int GoodsId
        {
            get
            {
                return goodsId;
            }

            set
            {
                goodsId = value;
            }
        }
    }
}
