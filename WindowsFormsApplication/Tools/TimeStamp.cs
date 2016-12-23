using System;

namespace Tools
{
    public class TimeStamp
    {
        /// <summary>
        /// 将时间戳转换为日期时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        public static System.DateTime ConvertIntDateTime(long timeStamp)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp.ToString() + "0000000");
            TimeSpan now = new TimeSpan(lTime);
            return dateTimeStart.Add(now);
        }

        /// <summary>
        /// 日期时间转换为时间戳
        /// </summary>
        /// <param name="time">日期时间</param>
        /// <returns></returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 获取当前的时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetNowTimeStamp()
        {
            return ConvertDateTimeInt(DateTime.Now);
        }
    }
}