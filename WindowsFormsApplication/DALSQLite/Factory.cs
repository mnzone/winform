using IDAL;

namespace DALSQLite
{
    public class Factory : IFactory
    {
        public IGoodsDAL CreateGoodsInstance()
        {
            throw new System.NotImplementedException();
        }

        public ISaleLogDAL CreateSaleLogInstance()
        {
            return new SaleLogDAL();
        }

        public IMemberCardDAL CreateMemberCardInstance()
        {
            throw new System.NotImplementedException();
        }

        public IMemberCardCategoryDAL CreateMemberCardCategoryInstance()
        {
            throw new System.NotImplementedException();
        }

        public IReportDAL CreateReportInstance()
        {
            throw new System.NotImplementedException();
        }

        public IGoodsCategoryDAL CreateGoodsCategoryInstance()
        {
            throw new System.NotImplementedException();
        }

        public IMemberCardRecordDAL CreateMemberCardRecordInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}
