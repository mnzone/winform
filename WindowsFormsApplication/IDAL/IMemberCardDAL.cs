using System;
using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IMemberCardDAL
    {
        int save(MemberCard model);

        int delete(int id);

        int update(MemberCard model);

        /// <summary>
        /// 根据会员ID查询会员卡信息
        /// </summary>
        /// <param name="id">会员卡ID</param>
        /// <returns></returns>
        MemberCard find(int id);

        /// <summary>
        /// 根据会员卡号查询会员卡信息
        /// </summary>
        /// <param name="no">会员卡号</param>
        /// <returns></returns>
        MemberCard find(String no);

        List<MemberCard> findAll();

        List<MemberCard> findByWhere(String where);
    }
}