using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace IDAL
{
    public interface IGoodsDAL
    {
        int save(Goods model);

        int delete(int id);

        int update(Goods model);

        Goods find(int id);

        List<Goods> findAll();

        List<Goods> findByWhere(String where);

        List<Goods> findByWhere(DbParameter[] where);

    }
}
