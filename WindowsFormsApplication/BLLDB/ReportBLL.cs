using System;
using System.Collections.Generic;
using IBLL;
using IDAL;
using Models;

namespace BLLDB
{
    public class ReportBLL : IReportBLL
    {
        private IReportDAL dal = null;

        public ReportBLL() { }

        public ReportBLL(Object startupPath)
        {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateReportInstance();
        }

        public List<ReportGoodsRank> SaleGoodsRank(int day)
        {
            DateTime begin = DateTime.Now.AddDays(- day);
            DateTime end = DateTime.Now;

            return dal.GetGoodsRank(begin, end);
        }

        public List<ReportGoodsRank> SaleGoodsRankByAll()
        {
            DateTime begin = Convert.ToDateTime("2014-01-01");
            DateTime end = DateTime.Now;

            return dal.GetGoodsRank(begin, end);
        }

        public List<ReportGoodsRank> GroupStatisticsByYear(int year)
        {
            return dal.GetYearStatistics(year);
        }

        public List<ReportGoodsRank> GroupStatisticsByDay(int year, int month)
        {
            return dal.GetMonthStatistics(year, month);
        }
    }
}