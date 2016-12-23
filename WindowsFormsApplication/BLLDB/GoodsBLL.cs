using IBLL;
using System;
using System.Collections.Generic;
using Models;
using IDAL;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace BLLDB
{
    public class GoodsBLL : IGoodsBLL
    {
        IGoodsDAL dal = null;

        public GoodsBLL() { }

        public GoodsBLL(Object startupPath) {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateGoodsInstance();
        }

        public bool AddGoods(Goods model)
        {
            //数据有效性检测

            //保存商品
            int result = dal.save(model);

            return result > 0;
        }

        public bool DeleteGoods(int id)
        {
            //删除商品
            int result = dal.delete(id);

            return result > 0;
        }

        public bool EditGoods(Goods model)
        {
            //更新商品
            int result = dal.update(model);

            return result > 0;
        }

        public List<Goods> GetAllGoods()
        {
            //获取商品列表
            List<Goods> result = dal.findAll();

            return result;
        }

        public List<Goods> GetSaleGoods()
        {
            DbParameter[] parameters =
            {
                new MySqlParameter("@visibile", MySqlDbType.Int32, 11)
                {
                    Value = 1
                },
                new MySqlParameter("@is_deleted", MySqlDbType.Int32, 11)
                {
                    Value = 0
                },
            };

            return dal.findByWhere(parameters);
        }

        public Goods GetGoodsById(int id)
        {
            //获取商品信息
            Goods result = dal.find(id);

            return result;
        }
    }
}
