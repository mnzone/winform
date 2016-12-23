namespace IDAL
{
    public interface IFactory
    {
        IGoodsDAL CreateGoodsInstance();

        ISaleLogDAL CreateSaleLogInstance();

        IMemberCardDAL CreateMemberCardInstance();

        IMemberCardCategoryDAL CreateMemberCardCategoryInstance();

        IReportDAL CreateReportInstance();

        IGoodsCategoryDAL CreateGoodsCategoryInstance();

        IMemberCardRecordDAL CreateMemberCardRecordInstance();
    }
}
