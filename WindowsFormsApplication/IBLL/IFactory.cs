using System;

namespace IBLL
{
    public interface IFactory
    {

        void SetStartupPath(String path);

        IGoodsBLL CreateGoodsInstance();

        IMemberCardBLL CreateMemberCardInstance();

        IMemberCardCategoryBLL CreateMemberCardCategoryInstance();

        IMemberCardCategoryValueBLL CreateMemberCardCategoryValueInstance();

        IMemberCardRecordBLL CreateMemberCardRecordInstance();

        ISaleLogBLL CreateSaleLogInstance();

        IReportBLL CreateReportInstance();

        IGoodsCategoryBLL CreateGoodsCategoryInstance();
    }
}
