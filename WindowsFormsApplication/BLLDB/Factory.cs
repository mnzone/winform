using IBLL;
using System;

namespace BLLDB
{
    public class Factory : IFactory
    {
        private String startupPath;

        public void SetStartupPath(string path)
        {
            this.StartupPath = path;
        }

        public IGoodsBLL CreateGoodsInstance()
        {
            return new GoodsBLL(this.StartupPath);
        }

        public IMemberCardCategoryBLL CreateMemberCardCategoryInstance()
        {
            return new MemberCardCategoryBLL(this.StartupPath);
        }

        public IMemberCardCategoryValueBLL CreateMemberCardCategoryValueInstance()
        {
            throw new NotImplementedException();
        }

        public IMemberCardBLL CreateMemberCardInstance()
        {
            return new MemberCardBLL(this.StartupPath);;
        }

        public IMemberCardRecordBLL CreateMemberCardRecordInstance()
        {
            return new MemberCardRecordBLL(this.StartupPath);
        }

        public ISaleLogBLL CreateSaleLogInstance()
        {
            return new SaleLogBLL(this.StartupPath);
        }

        public IReportBLL CreateReportInstance()
        {
            return new ReportBLL(this.StartupPath);
        }

        public IGoodsCategoryBLL CreateGoodsCategoryInstance()
        {
            return new GoodsCategoryBLL(this.StartupPath);
        }

        public string StartupPath
        {
            get
            {
                return startupPath;
            }

            set
            {
                startupPath = value;
            }
        }
    }
}
