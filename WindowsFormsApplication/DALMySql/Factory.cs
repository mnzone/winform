using IDAL;

namespace DALMySql
{
    public class Factory : IFactory
    {
        /// <summary>
        /// 获取商品DAL
        /// </summary>
        /// <returns></returns>
        public IGoodsDAL CreateGoodsInstance()
        {
            return new GoodsDAL();
        }

        public ISaleLogDAL CreateSaleLogInstance()
        {
            return new SaleLogDAL();
        }

        public IMemberCardDAL CreateMemberCardInstance()
        {
            return new MemberCardDAL();
        }

        public IMemberCardCategoryDAL CreateMemberCardCategoryInstance()
        {
            return new MemberCardCategoryDAL();
        }

        public IMemberCardCategoryValueDAL CreateMemberCardCategoryValueInstance()
        {
            return new MemberCardCategoryValueDAL();
        }

        public IReportDAL CreateReportInstance()
        {
            return new ReportDAL();
        }

        public IGoodsCategoryDAL CreateGoodsCategoryInstance()
        {
            return new GoodsCategoryDAL();
        }

        public IMemberCardRecordDAL CreateMemberCardRecordInstance()
        {
            return new MemberCardRecordDAL();
        }
    }
}
