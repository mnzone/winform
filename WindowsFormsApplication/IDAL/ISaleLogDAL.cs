using System;
using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface ISaleLogDAL
    {
        int save(SaleLog model);

        int save(List<SaleLog> model);

        int delete(int id);

        int update(SaleLog model);

        SaleLog find(int id);

        List<SaleLog> findAll();

        List<SaleLog> findByWhere(String where);
    }
}