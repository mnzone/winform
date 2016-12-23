using IDAL;
using System;
using System.Configuration;
using Tools;

namespace BLLDB
{
    public class DALFactory
    {
        public static String StartupPath;

        public static ISaleLogDAL CreateSaleLogInstance()
        {
            return GetDALFactory().CreateSaleLogInstance();
        }

        public static IGoodsDAL CreateGoodsInstance() {
            
            return GetDALFactory().CreateGoodsInstance();
        }

        internal static IMemberCardRecordDAL CreateMemberCardRecordInstance()
        {
            return GetDALFactory().CreateMemberCardRecordInstance();
        }

        internal static IMemberCardCategoryDAL CreateMemberCardCategoryInstance()
        {
            return GetDALFactory().CreateMemberCardCategoryInstance();
        }

        public static IMemberCardDAL CreateMemberCardInstance()
        {
            return GetDALFactory().CreateMemberCardInstance();
        }

        internal static IGoodsCategoryDAL CreateGoodsCategoryInstance()
        {
            return GetDALFactory().CreateGoodsCategoryInstance();
        }

        public static IReportDAL CreateReportInstance()
        {
            return GetDALFactory().CreateReportInstance();
        }

        /// <summary>
        /// 获取DAL创建工厂
        /// </summary>
        /// <returns></returns>
        private static IFactory GetDALFactory() {
            String DALPath = ConfigurationManager.AppSettings["DALModule"].ToString();
            IFactory factory = ReflectionTools.GetConstructor(StartupPath, DALPath, String.Format("{0}.Factory", DALPath)) as IFactory;
            return factory;
        }
    }
}
