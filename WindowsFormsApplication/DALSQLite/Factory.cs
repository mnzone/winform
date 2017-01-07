using IDAL;

namespace DALSQLite
{
    public class Factory : IFactory
    {
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
