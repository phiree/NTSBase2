using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDAL
{
    public class DALMembership : DalBase<NModel.NTSMember>
    {
        public NModel.NTSMember GetByUserName(string username)
        {
            return GetByUserName(username, false);

        }
        public NModel.NTSMember GetByUserName(string username, bool setOnlineStatus)
        {
            string query = "select m from NTSMember m where m.Name='" + username + "'";

            NModel.NTSMember member = GetOneByQuery(query);
            return member;
        }
        public bool ValidateUser(string username, string encryptedPwd)
        {
            string query = "select m from NTSMember m where m.Name='" + username
                   + "' and  m.Password='" + encryptedPwd + "'";
            NModel.NTSMember member = GetOneByQuery(query);
            return member != null;
        }
        public IList<NModel.NTSMember> GetMemberList(int pageIndex, int pageSize, out int totalRecord)
        {
            string query = "select m from NTSMember m";
            return GetList(query, pageIndex, pageSize, out totalRecord);
        }
    }
}
