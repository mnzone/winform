namespace IDAL
{
    public interface IFactory
    {
        IGoodsDAL CreateGoodsInstance();

        ISaleLogDAL CreateSaleLogInstance();

        IMemberCardDAL CreateMemberCardInstance();

        IMemberCardCategoryDAL CreateMemberCardCategoryInstance();

        IMemberCardCategoryValueDAL CreateMemberCardCategoryValueInstance();

        IReportDAL CreateReportInstance();

        IGoodsCategoryDAL CreateGoodsCategoryInstance();

        IMemberCardRecordDAL CreateMemberCardRecordInstance();
    }
}
