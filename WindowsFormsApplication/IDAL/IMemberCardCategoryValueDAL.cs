using System;
using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IMemberCardCategoryValueDAL
    {
        int save(MemberCardCategoryValue model);

        int delete(int id);

        int update(MemberCardCategoryValue model);

        /// <summary>
        /// 根据会员ID查询会员卡分类信息
        /// </summary>
        /// <param name="id">会员卡分类ID</param>
        /// <returns></returns>
        MemberCardCategoryValue find(int id);


        List<MemberCardCategoryValue> findAll();

        List<MemberCardCategoryValue> findByWhere(String where);
    }
}