using System;

namespace Models
{
    public class MemberCardCategory
    {
        private int id;
        private String name;
        private String notAllow;
        private String beginAt;
        private String endAt;
        private int createdAt;
        private int updatedAt;

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

        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public String BeginAt
        {
            get
            {
                return beginAt;
            }

            set
            {
                beginAt = value;
            }
        }

        public String EndAt
        {
            get
            {
                return endAt;
            }

            set
            {
                endAt = value;
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

        /// <summary>
        /// 取值范围1：Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday
        /// 取值范围2：20160101
        /// </summary>
        public string NotAllow
        {
            get
            {
                return notAllow;
            }

            set
            {
                notAllow = value;
            }
        }

        /// <summary>
        /// 是否允许今日使用
        /// </summary>
        /// <returns></returns>
        public bool isDateAllow()
        {
            if (String.IsNullOrEmpty(this.notAllow))
            {
                return true;
            }
            
            String[] days = this.notAllow.Split(',');
            if (Array.IndexOf(days, DateTime.Now.DayOfWeek) == -1)
            {
                return true;
            }else if (Array.IndexOf(days, DateTime.Now.ToString("yyyyMMdd")) == -1)
            {
                return true;
            }

            return false;
        }

        public bool isTimeAllow()
        {
            String begin = DateTime.Now.ToString("yyyy-MM-dd") + " " + this.BeginAt;
            String end = DateTime.Now.ToString("yyyy-MM-dd") + " " + this.EndAt;

            return Convert.ToDateTime(begin) <= DateTime.Now && Convert.ToDateTime(end) >= DateTime.Now;
        }
    }
}
