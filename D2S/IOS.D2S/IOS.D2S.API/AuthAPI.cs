using IOS.D2S.BL;
using IOS.D2S.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.API
{
    public class AuthAPI
    {
        public static User GetUserByCredentials(string userName, string password)
        {
            return AuthBL.GetUserByCredentials(userName, password);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>


        public static List<User> GetUsers(int branchId)
        {
            return AuthBL.GetUsers(branchId);
        }

        public static bool DeleteUser(int userId)
        {
            return AuthBL.DeleteUser(userId);
        }

        public static int InsertOrUpdateUser(User user)
        {
            return AuthBL.InsertOrUpdateUser(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>

        public static List<UserRole> GetUserRoles(int branchId)
        {
            return AuthBL.GetUserRoles(branchId);
        }

        public static bool DeleteUserRole(int roleId)
        {
            return AuthBL.DeleteUserRole(roleId);
        }

        public static int InsertOrUpdateUserRole(UserRole role)
        {
            return AuthBL.InsertOrUpdateUserRole(role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>

        public static List<UserGroup> GetUserGroups(int branchId)
        {
            return AuthBL.GetUserGroups(branchId);
        }

        public static bool DeleteUserGroup(int groupId)
        {
            return AuthBL.DeleteUserGroup(groupId);
        }

        public static int InsertOrUpdateUserGroup(UserGroup group)
        {
            return AuthBL.InsertOrUpdateUserGroup(group);
        }

        public static List<Module> GetModulesByRole(int roleId,int branchId)
        {
            return AuthBL.GetModulesByRole(roleId, branchId);
        }

        public static List<Operation> getOperations(int branchId)
        {
            return AuthBL.getOperations(branchId);
        }

        public static bool AssignPermissions(List<Module> modules)
        {
            return AuthBL.AssignPermissions(modules);
        }


    }
}
