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

        /// <summary>
        /// 根据分类及时间段统计销售数量及销售金额
        /// </summary>
        /// <param name="catId">分类ID</param>
        /// <param name="beginAt">开始时间</param>
        /// <param name="endAt">结束时间</param>
        /// <returns></returns>
        List<ReportGoodsRank> GetStatisticsByCategory(int catId, long beginAt, long endAt);
    }
}