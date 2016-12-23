using System;
using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IReportDAL
    {
        /// <summary>
        /// 返回某时间段的销售排行榜
        /// </summary>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        List<ReportGoodsRank> GetGoodsRank(DateTime begin, DateTime end);

        /// <summary>
        /// 按月分组统计指定年份的销售额
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        List<ReportGoodsRank> GetYearStatistics(int year);

        /// <summary>
        /// 根据年月统计销售额
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        List<ReportGoodsRank> GetMonthStatistics(int year, int month);
    }
}