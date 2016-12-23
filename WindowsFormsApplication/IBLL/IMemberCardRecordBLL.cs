using System;
using System.Collections.Generic;
using Models;

namespace IBLL
{
    public interface IMemberCardRecordBLL
    {
        Boolean AddMemberCardRecord(MemberCardRecord model);

        Boolean DeleteMemberCardRecord(int id);

        Boolean EditMemberCardRecord(MemberCardRecord model);

        MemberCardRecord GetMemberCardRecordById(int id);
        
        MemberCardRecord GetMemberCardRecordByMemberCardId(int cardId);

        List<MemberCardRecord> GetMemberCardRecordByMembersCardId(int cardId);

        List<MemberCardRecord> GetAllMemberCardRecord();

        List<MemberCardRecord> GetMemberCardRecordByWhere(String where);
    }
}
