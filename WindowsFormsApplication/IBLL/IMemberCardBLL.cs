using System;
using System.Collections.Generic;
using Models;

namespace IBLL
{
    public interface IMemberCardBLL
    {
        /// <summary>
        /// 添加会员卡
        /// </summary>
        /// <param name="model">会员卡数据实体</param>
        /// <returns>添加成功返回True,否则返回False</returns>
        Boolean AddMemberCard(MemberCard model);

        /// <summary>
        /// 删除会员卡
        /// </summary>
        /// <param name="id">会员卡ID</param>
        /// <returns>删除成功返回True，否则返回False</returns>
        Boolean DeleteMemberCard(int id);

        /// <summary>
        /// 删除会员卡
        /// </summary>
        /// <param name="no">会员卡号</param>
        /// <returns></returns>
        Boolean DeleteMemberCard(String no);

        /// <summary>
        /// 编辑会员卡信息
        /// </summary>
        /// <param name="model">会员卡实体</param>
        /// <returns>编辑成功返回True，否则返回False</returns>
        Boolean EditMemberCard(MemberCard model);

        /// <summary>
        /// 获取所有会员卡
        /// </summary>
        /// <returns>会员卡实体列表</returns>
        List<MemberCard> GetAllMemberCard();

        /// <summary>
        /// 根据会员卡ID获取会员卡信息
        /// </summary>
        /// <param name="id">会员卡ID</param>
        /// <returns>返回会员卡实体或NULL</returns>
        MemberCard GetMemberCardById(int id);

        /// <summary>
        /// 根据会员卡号获取会员卡信息
        /// </summary>
        /// <returns></returns>
        MemberCard GetMemberCardByNo(String no);
    }
}
