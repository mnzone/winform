using System;
using System.Collections.Generic;
using IBLL;
using IDAL;
using Models;
using Tools;

namespace BLLDB
{
    public class SaleLogBLL : ISaleLogBLL
    {
        private ISaleLogDAL dal = null;

        public SaleLogBLL() { }

        public SaleLogBLL(Object startupPath)
        {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateSaleLogInstance();
        }

        public List<SaleLog> GetAllSaleLogs()
        {
            return dal.findAll();
        }

        public List<SaleLog> GetAllSaleLogsByDate(DateTime begin, DateTime end)
        {
            return dal.findByWhere(String.Format("created_at BETWEEN {0} AND {1}", TimeStamp.ConvertDateTimeInt(begin), TimeStamp.ConvertDateTimeInt(end)));
        }

        public bool AddLog(SaleLog model)
        {
            return dal.save(model) > 0;
        }

        public bool AddLog(List<SaleLog> list)
        {
            return dal.save(list) >= list.Count;
        }

        public bool DeleteLog(int id)
        {
            return dal.delete(id) > 0;
        }

        public bool EditLog(SaleLog model)
        {
            return dal.update(model) > 0;
        }

        public List<SaleLog> GetSaleLogsByLastId(int id)
        {
            return dal.findByWhere(String.Format("id > {0}", id));
        }
    }
}