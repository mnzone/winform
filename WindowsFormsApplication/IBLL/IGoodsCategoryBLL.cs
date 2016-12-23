using System.Collections.Generic;
using Models;

namespace IBLL
{
    public interface IGoodsCategoryBLL
    {
        /// <summary>
        /// 获取所有商品分类信息
        /// </summary>
        /// <returns></returns>
        List<GoodsCategory> GetAllCategories();

        /// <summary>
        /// 获取商品分类信息
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        GoodsCategory GetCategory(int id);
    }
}