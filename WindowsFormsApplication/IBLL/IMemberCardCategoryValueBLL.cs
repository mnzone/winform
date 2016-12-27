using System;
using System.Collections.Generic;
using Models;

namespace IBLL
{
    public interface IMemberCardCategoryValueBLL
    {
        /// <summary>
        /// 添加会员卡充值规则
        /// </summary>
        /// <param name="model">会员卡充值规则数据实体</param>
        /// <returns>添加成功返回True,否则返回False</returns>
        Boolean AddMemberCardCategoryValue(MemberCardCategoryValue model);

        /// <summary>
        /// 删除会员卡充值规则
        /// </summary>
        /// <param name="id">会员卡充值规则</param>
        /// <returns>删除成功返回True，否则返回False</returns>
        Boolean DeleteMemberCardCategoryValue(int id);


        /// <summary>
        /// 编辑会员卡充值规则
        /// </summary>
        /// <param name="model">会员卡充值规则实体</param>
        /// <returns>编辑成功返回True，否则返回False</returns>
        Boolean EditMemberCardCategory(MemberCardCategoryValue model);

        /// <summary>
        /// 获取所有会员卡充值规则
        /// </summary>
        /// <returns>会员卡充值规则实体列表</returns>
        List<MemberCardCategoryValue> GetAllMemberCardCategoryValue();

        /// <summary>
        /// 根据会员卡充值规则ID获取会员卡充值规则信息
        /// </summary>
        /// <param name="id">会员卡规则ID</param>
        /// <returns>返回会员卡充值规则实体或NULL</returns>
        MemberCardCategoryValue GetMemberCardCategoryValueById(int id);

        /// <summary>
        /// 根据会员卡类别获取会员卡充值规则信息
        /// </summary>
        /// <param name="id">会员卡类别ID</param>
        /// <returns></returns>
        List<MemberCardCategoryValue> GetAllMemberCardCategoryValuesByCategoryId(int id);
    }
}
