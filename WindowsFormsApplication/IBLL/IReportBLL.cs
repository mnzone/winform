using System.Collections.Generic;
using Models;

namespace IBLL
{
    public interface IReportBLL
    {

        /// <summary>
        /// 返回指定最近指定天数的销售排行榜
        /// </summary>
        /// <param name="day">天数</param>
        /// <returns></returns>
        List<ReportGoodsRank> SaleGoodsRank(int day);

        /// <summary>
        /// 返回整体销售排行榜
        /// </summary>
        /// <returns></returns>
        List<ReportGoodsRank> SaleGoodsRankByAll();

        /// <summary>
        /// 按月分组，根据年份统计数据
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        List<ReportGoodsRank> GroupStatisticsByYear(int year);

        /// <summary>
        /// 按天分组，根据年月统计数据
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        List<ReportGoodsRank> GroupStatisticsByDay(int year, int month);
    }
}