using System;
using System.Collections.Generic;
using IBLL;
using IDAL;
using Models;

namespace BLLDB
{
    public class MemberCardRecordBLL : IMemberCardRecordBLL
    {
        IMemberCardRecordDAL dal = null;

        public MemberCardRecordBLL() { }

        public MemberCardRecordBLL(Object startupPath)
        {
            DALFactory.StartupPath = startupPath as String;
            dal = DALFactory.CreateMemberCardRecordInstance();
        }

        public Boolean AddMemberCardRecord(MemberCardRecord model)
        {
            return dal.save(model) > 0;
        }

        public Boolean DeleteMemberCardRecord(int id)
        {
            return dal.delete(id) > 0;
        }

        public Boolean EditMemberCardRecord(MemberCardRecord model)
        {
            return dal.update(model) > 0;
        }

        public MemberCardRecord GetMemberCardRecordById(int id)
        {
            throw new NotImplementedException();
        }

        public MemberCardRecord GetMemberCardRecordByMemberCardId(int cardId)
        {
            List<MemberCardRecord> list = dal.findByWhere(String.Format("member_card_id = {0} AND begin_at < {1} AND expired_at > {1}", cardId, Tools.TimeStamp.GetNowTimeStamp()));
            return list == null || list.Count < 1 ? null : list[0];
        }

        public List<MemberCardRecord> GetMemberCardRecordByMembersCardId(int cardId)
        {
            return dal.findByWhere(String.Format("member_card_id = {0}", cardId));
        }

        public List<MemberCardRecord> GetAllMemberCardRecord()
        {
            throw new NotImplementedException();
        }

        public List<MemberCardRecord> GetMemberCardRecordByWhere(string @where)
        {
            throw new NotImplementedException();
        }
    }
}