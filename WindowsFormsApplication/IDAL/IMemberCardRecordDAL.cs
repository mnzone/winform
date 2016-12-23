using System;
using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IMemberCardRecordDAL
    {
        int save(MemberCardRecord model);

        int delete(int id);

        int update(MemberCardRecord model);

        /// <summary>
        /// 根据会员ID查询会员卡信息
        /// </summary>
        /// <param name="id">会员卡ID</param>
        /// <returns></returns>
        MemberCardRecord find(int id);

        /// <summary>
        /// 根据会员卡ID查找会员开卡记录
        /// </summary>
        /// <param name="cardId">会员卡ID</param>
        /// <returns></returns>
        MemberCardRecord findByCardId(int cardId);

        List<MemberCardRecord> findAll();

        List<MemberCardRecord> findByWhere(String where);
    }
}