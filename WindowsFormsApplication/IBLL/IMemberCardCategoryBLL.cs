using System;
using System.Collections.Generic;
using Models;

namespace IBLL
{
    public interface IMemberCardCategoryBLL
    {
        /// <summary>
        /// 添加会员卡类别
        /// </summary>
        /// <param name="model">会员卡类别数据实体</param>
        /// <returns>添加成功返回True,否则返回False</returns>
        Boolean AddMemberCardCategory(MemberCardCategory model);

        /// <summary>
        /// 删除会员卡类别
        /// </summary>
        /// <param name="id">会员卡类别ID</param>
        /// <returns>删除成功返回True，否则返回False</returns>
        Boolean DeleteMemberCardCategory(int id);
        

        /// <summary>
        /// 编辑会员卡类别信息
        /// </summary>
        /// <param name="model">会员卡类别实体</param>
        /// <returns>编辑成功返回True，否则返回False</returns>
        Boolean EditMemberCardCategory(MemberCardCategory model);

        /// <summary>
        /// 获取所有会员卡类别
        /// </summary>
        /// <returns>会员卡类别实体列表</returns>
        List<MemberCardCategory> GetAllMemberCardCategory();

        /// <summary>
        /// 根据会员卡类别ID获取会员卡类别信息
        /// </summary>
        /// <param name="id">会员卡类别ID</param>
        /// <returns>返回会员卡类别实体或NULL</returns>
        MemberCardCategory GetMemberCardCategoryById(int id);
        
    }
}
