using IBLL;
using System;
using System.Collections.Generic;
using Models;
using IDAL;

namespace BLLDB
{
    public class GoodsCategoryBLL : IGoodsCategoryBLL
    {
        IGoodsCategoryDAL dal = null;

        public GoodsCategoryBLL() { }

        public GoodsCategoryBLL(Object startupPath) {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateGoodsCategoryInstance();
        }

        public List<GoodsCategory> GetAllCategories()
        {
            return dal.findAll();
        }

        public GoodsCategory GetCategory(int id)
        {
            return dal.find(id);
        }
    }
}
