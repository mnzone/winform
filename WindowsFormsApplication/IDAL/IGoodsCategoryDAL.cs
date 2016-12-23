using System;
using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IGoodsCategoryDAL
    {
        int save(GoodsCategory model);

        int delete(int id);

        int update(GoodsCategory model);

        GoodsCategory find(int id);

        List<GoodsCategory> findAll();

        List<GoodsCategory> findByWhere(String where);
    }
}