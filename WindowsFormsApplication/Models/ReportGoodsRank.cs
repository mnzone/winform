using System;

namespace Models
{
    /// <summary>
    /// 销售排行榜数据模型
    /// </summary>
    public class ReportGoodsRank
    {
        private int id;
        private int month;
        private String goodsName;
        private int count;
        private Decimal price;

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

        public string GoodsName
        {
            get
            {
                return goodsName;
            }

            set
            {
                goodsName = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public Decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }
    }
}