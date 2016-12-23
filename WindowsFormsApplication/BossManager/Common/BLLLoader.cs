using System;
using System.Reflection;
using IBLL;
using System.Configuration;
using System.Windows.Forms;
using Tools;

namespace BossManager.Common
{
    public class BLLLoader
    {
        public static IGoodsBLL GetGoodsBll()
        {
            IFactory factory = GetBllFactory();
            if (factory == null)
            {
                throw new NullReferenceException("factory is null");
            }
            return factory.CreateGoodsInstance();
        }

        public static ISaleLogBLL GetSaleLogBll()
        {
            IFactory factory = GetBllFactory();
            if (factory == null)
            {
                throw new NullReferenceException("factory is null");
            }
            return factory.CreateSaleLogInstance();
        }

        public static IGoodsCategoryBLL GetGoodsCategoryBll()
        {
            IFactory factory = GetBllFactory();
            if (factory == null)
            {
                throw new NullReferenceException("factory is null");
            }
            return factory.CreateGoodsCategoryInstance();
        }

        public static IReportBLL GetReportBll()
        {
            IFactory factory = GetBllFactory();
            if (factory == null)
            {
                throw new NullReferenceException("factory is null");
            }
            return factory.CreateReportInstance();
        }

        /// <summary>
        /// 获取BLL构造器
        /// </summary>
        /// <returns></returns>
        private static IFactory GetBllFactory()
        {
            String BLLPath = ConfigurationManager.AppSettings["BLLModule"].ToString();
            Type type = ReflectionTools.GetTypeObject(Application.StartupPath, BLLPath, String.Format("{0}.Factory", BLLPath));
            if (type == null)
                throw new MissingMethodException("Factory not found!");

            ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
            if (constructor == null)
                throw new MissingMethodException("No public constructor defined for this object");

            IFactory factory = constructor.Invoke(null) as IFactory;
            factory.SetStartupPath(Application.StartupPath);
            return factory;
        }
    }
}