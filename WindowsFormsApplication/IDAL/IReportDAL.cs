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
        /// 根据SQL获取商品销售统计数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        List<ReportGoodsRank> GetStatisticsBySql(String sql);
    }
}