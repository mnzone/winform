using System;

namespace Models
{
    public class SaleLog : BaseModel
    {
        private int id;
        private int goodsId;
        private int memberId;
        private String memberNo;
        private Decimal money;
        private long createdAt;
        private long updatedAt;
        private String summary;
        private String remark;

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

        public long CreatedAt
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

        public long UpdatedAt
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

        public string Summary
        {
            get
            {
                return summary;
            }

            set
            {
                summary = value;
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

        public int MemberId
        {
            get
            {
                return memberId;
            }

            set
            {
                memberId = value;
            }
        }

        public string MemberNo
        {
            get
            {
                return memberNo;
            }

            set
            {
                memberNo = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }
    }
}
