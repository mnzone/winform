using System;
using System.Collections.Generic;
using IBLL;
using IDAL;
using Models;

namespace BLLDB
{
    public class MemberCardCategoryValueBLL : IMemberCardCategoryValueBLL
    {
        IMemberCardCategoryValueDAL dal = null;

        public MemberCardCategoryValueBLL()
        {
        }

        public MemberCardCategoryValueBLL(String startupPath)
        {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateMemberCardCategoryValueInstance();
        }

        public bool DeleteMemberCardCategoryValue(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool EditMemberCardCategory(MemberCardCategoryValue model)
        {
            throw new System.NotImplementedException();
        }

        public List<MemberCardCategoryValue> GetAllMemberCardCategoryValue()
        {
            throw new System.NotImplementedException();
        }

        public MemberCardCategoryValue GetMemberCardCategoryValueById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<MemberCardCategoryValue> GetAllMemberCardCategoryValuesByCategoryId(int id)
        {
            return dal.findByWhere(String.Format("member_card_category_id = {0}", id));
        }

        public bool AddMemberCardCategoryValue(MemberCardCategoryValue model)
        {
            throw new System.NotImplementedException();
        }
    }
}