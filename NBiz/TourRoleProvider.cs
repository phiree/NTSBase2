using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDAL;
using NModel;
namespace NBiz
{
  public class TourRoleProvider:System.Web.Security.RoleProvider
    {
        DALRole  iRole;
        public TourRoleProvider()
        {
            iRole = new DALRole();
        }
        public TourRoleProvider(DalBase<Role> roleDal)
        {
            iRole =(DALRole)roleDal;
            }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
           ((DALRole) iRole).AddUsersToRoles(usernames, roleNames);
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            Role role=new Role();
            role.Name=roleName;
            iRole.CreateRole(role);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            iRole.DeleteRole(roleName);
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            IList<Role> AllRoles = iRole.GetAllRoles();
            List<string> AllRoleNames = new List<string>();
            foreach (Role role in AllRoles)
            {
                AllRoleNames.Add(role.Name);
            }
            return AllRoleNames.ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
          return  iRole.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return iRole.GetUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return iRole.IsUserInRole(username,roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            iRole.RemoveUsersFromRoles(usernames, roleNames);
        }

        public override bool RoleExists(string roleName)
        {
            return iRole.IsRoleExists(roleName);
        }
    }
}
