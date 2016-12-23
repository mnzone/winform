using System;
using System.Collections.Generic;
using Models;

namespace IBLL
{
    public interface ISaleLogBLL
    {
        List<SaleLog> GetAllSaleLogs();

        List<SaleLog> GetAllSaleLogsByDate(DateTime begin, DateTime end);

        /// <summary>
        /// 获取大于指定ID的所有记录
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        List<SaleLog> GetSaleLogsByLastId(int id);

        Boolean AddLog(SaleLog model);

        Boolean AddLog(List<SaleLog> list);

        Boolean DeleteLog(int id);

        Boolean EditLog(SaleLog model);
    }
}
