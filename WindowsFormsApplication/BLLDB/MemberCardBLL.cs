using System;
using System.Collections.Generic;
using IBLL;
using IDAL;
using Models;

namespace BLLDB
{
    public class MemberCardBLL : IMemberCardBLL
    {
        IMemberCardDAL dal = null;

        public MemberCardBLL() { }

        public MemberCardBLL(Object startupPath)
        {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateMemberCardInstance();
        }

        public bool AddMemberCard(MemberCard model)
        {
            //验证数据合法性
            if (model.Id == 0)
            {
                throw new ArgumentException("会员ID必须为0");
            }
            this.valid(model);

            //持久化操作
            return dal.save(model) > 0;
        }

        public bool DeleteMemberCard(int id)
        {
            //验证数据合法性
            if (id < 1)
            {
                throw new ArgumentNullException("无效的会员卡ID");
            }
            //持久化操作
            return dal.delete(id) > 0;
        }

        public bool DeleteMemberCard(string no)
        {
            //验证数据合法性
            if (String.IsNullOrEmpty(no))
            {
                throw new ArgumentNullException("无效的会员卡号");
            }

            MemberCard card = dal.find(no);
            //持久化操作
            return dal.delete(card.Id) > 0;
        }

        public bool EditMemberCard(MemberCard model)
        {
            //验证数据合法性
            if (model.Id < 1)
            {
                throw new ArgumentException("非法的会员ID");
            }
            this.valid(model);

            //持久化操作
            return dal.update(model) > 0;
        }

        public List<MemberCard> GetAllMemberCard()
        {
            return dal.findAll();
        }

        public MemberCard GetMemberCardById(int id)
        {
            return dal.find(id);
        }

        public MemberCard GetMemberCardByNo(string no)
        {
            return dal.find(no);
        }

        private void valid(MemberCard model)
        {
            if (String.IsNullOrEmpty(model.CardNo))
            {
                throw new ArgumentNullException("会员卡号不能为空");
            }
            else if (model.CategoryId < 1)
            {
                throw new ArgumentNullException("会员卡所属类别必选");
            }

            MemberCard card = dal.find(model.CardNo);
            if (model.Id != card.Id
                && model.CardNo == card.CardNo)
            {
                throw new ArgumentException("该会员卡号已存在，请重新输入");
            }
        }
    }
}