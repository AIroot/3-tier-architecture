using IOS.D2S.Core.DomainObjects;
using IOS.D2S.Data.AUTCommands.CommandActions;
using IOS.D2S.DataConnector.DBFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Data.AUTCommands
{
    public class AUTDataManager
    {

        public static User GetUserByCredentials(string userName, string password)
        {
            try
            {

                GetUserByCredentialsAction commd = new GetUserByCredentialsAction(userName, password);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<Feature> GetFeatureByRoleModule(int roleId, int moduleId, int branchId)
        {
            try
            {

                GetFeatureByRoleModuleAction commd = new GetFeatureByRoleModuleAction(roleId, moduleId, branchId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Module> GetModulesByRole(int roleId, int branchId)
        {
            try
            {

                GetModulesByRoleAction commd = new GetModulesByRoleAction(roleId, branchId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Operation> GetOperations(int branchId)
        {
            try
            {
                GetOperationsAction commd = new GetOperationsAction(branchId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool InsertOrUpdateRolePrivilage(RolePrivilage rolePrivilage)
        {
            try
            {
                InsertOrUpdateRolePrivilageAction commd = new InsertOrUpdateRolePrivilageAction(rolePrivilage);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception)
            {

                throw;
            }
        }



        public static List<User> GetUsers(int branchId)
        {
            try
            {
                GetUserByBranchIdAction commd = new GetUserByBranchIdAction(branchId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteUser(int userId)
        {
            try
            {
                DeleteUserByUserIdAction commd = new DeleteUserByUserIdAction(userId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateUser(User user)
        {
            try
            {
                InsertOrUpdateUserAction commd = new InsertOrUpdateUserAction(user);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<UserRole> GetUserRoles(int branchId)
        {
            try
            {
                GetUserRolesByBranchIdAction commd = new GetUserRolesByBranchIdAction(branchId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteUserRole(int roleId)
        {
            try
            {
                DeleteUserRoleByRoleIdAction commd = new DeleteUserRoleByRoleIdAction(roleId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateUserRole(UserRole role)
        {
            try
            {
                InsertOrUpdateUserRoleAction commd = new InsertOrUpdateUserRoleAction(role);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>

        public static List<UserGroup> GetUserGroups(int branchId)
        {
            try
            {
                GetUserGroupsByBranchIdAction commd = new GetUserGroupsByBranchIdAction(branchId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteUserGroup(int groupId)
        {
            try
            {
                DeleteUserGroupByGroupIdAction commd = new DeleteUserGroupByGroupIdAction(groupId);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateUserGroup(UserGroup group)
        {
            try
            {
                InsertOrUpdateUserGroupAction commd = new InsertOrUpdateUserGroupAction(group);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int AssignPermissions(Module module)
        {
            return 1;
        }
    }
}
