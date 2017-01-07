using System;
using System.Collections.Generic;
using System.Data.Common;
using Models;

namespace IDAL
{
    public interface IMemberCardCategoryDAL
    {
        int save(MemberCardCategory model);

        int delete(int id);

        int update(MemberCardCategory model);

        /// <summary>
        /// 根据会员ID查询会员卡分类信息
        /// </summary>
        /// <param name="id">会员卡分类ID</param>
        /// <returns></returns>
        MemberCardCategory find(int id);
        

        List<MemberCardCategory> findAll();

        List<MemberCardCategory> findByWhere(String where);

        List<MemberCardCategory> findByWhere(String where, DbParameter[] whereParameters);
    }
}