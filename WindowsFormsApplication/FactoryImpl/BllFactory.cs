using IBLL;
using System;
using System.Configuration;
using System.Net.Mime;
using System.Reflection;
using Tools;

namespace FactoryImpl
{
    public class BllFactory
    {

        public static String DLLBasePath = "";

        private static IFactory GetIFactory()
        {
            IFactory factory = GetBllFactory();
            if (factory == null)
            {
                throw new NullReferenceException("factory is null");
            }
            return factory;
        }

        public static IGoodsBLL GetGoodsBll()
        {
            return GetIFactory().CreateGoodsInstance();
        }

        public static IGoodsCategoryBLL GetGoodsCategoryBll()
        {
            return GetIFactory().CreateGoodsCategoryInstance();
        }

        public static ISaleLogBLL GetSaleLogBll()
        {
            return GetIFactory().CreateSaleLogInstance();
        }

        public static IMemberCardBLL GetMemberCardBll()
        {
            return GetIFactory().CreateMemberCardInstance();
        }

        public static IMemberCardCategoryBLL GetMemberCardCategoryBll()
        {
            return GetIFactory().CreateMemberCardCategoryInstance();
        }

        public static IMemberCardCategoryValueBLL GetMemberCardCategoryValueBll()
        {
            return GetIFactory().CreateMemberCardCategoryValueInstance();
        }

        public static IMemberCardRecordBLL GetMemberCardRecordBll()
        {
            return GetIFactory().CreateMemberCardRecordInstance();
        }

        public static IReportBLL GetReportBll()
        {
            return GetIFactory().CreateReportInstance();
        }

        /// <summary>
        /// 获取BLL构造器
        /// </summary>
        /// <returns></returns>
        private static IFactory GetBllFactory()
        {
            String BLLPath = ConfigurationManager.AppSettings["BLLModule"].ToString();
            Type type = ReflectionTools.GetTypeObject(DLLBasePath, BLLPath, String.Format("{0}.Factory", BLLPath));
            if (type == null)
                throw new MissingMethodException("Factory not found!");

            ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
            if (constructor == null)
                throw new MissingMethodException("No public constructor defined for this object");

            IFactory factory = constructor.Invoke(null) as IFactory;
            factory.SetStartupPath(DLLBasePath);
            return factory;
        }
    }
}