using System;
using System.Collections.Generic;
using IBLL;
using IDAL;
using Models;

namespace BLLDB
{
    public class MemberCardCategoryBLL : IMemberCardCategoryBLL
    {
        IMemberCardCategoryDAL dal = null;

        public MemberCardCategoryBLL() { }

        public MemberCardCategoryBLL(Object startupPath)
        {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateMemberCardCategoryInstance();
        }

        public bool AddMemberCardCategory(MemberCardCategory model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteMemberCardCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool EditMemberCardCategory(MemberCardCategory model)
        {
            throw new System.NotImplementedException();
        }

        public List<MemberCardCategory> GetAllMemberCardCategory()
        {
            return dal.findAll();
        }

        public MemberCardCategory GetMemberCardCategoryById(int id)
        {
            return dal.find(id);
        }
    }
}