using Models;
using System;
using System.Collections.Generic;

namespace IBLL
{
    public interface IGoodsBLL
    {
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="model">商品数据实体</param>
        /// <returns>添加成功返回True,否则返回False</returns>
        Boolean AddGoods(Goods model);

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>删除成功返回True，否则返回False</returns>
        Boolean DeleteGoods(int id);

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="model">商品实体</param>
        /// <returns>编辑成功返回True，否则返回False</returns>
        Boolean EditGoods(Goods model);

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns>商品实体列表</returns>
        List<Goods> GetAllGoods();

        /// <summary>
        /// 获取销售商品列表
        /// </summary>
        /// <returns></returns>
        List<Goods> GetSaleGoods();

            /// <summary>
        /// 根据商品ID获取商品信息
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>返回商品实体或NULL</returns>
        Goods GetGoodsById(int id);
        
    }
}
