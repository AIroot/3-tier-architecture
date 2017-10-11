using IOS.D2S.Core.DomainObjects;
using IOS.D2S.Data.AUTCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.BL
{
    public class AuthBL
    {
        public static User GetUserByCredentials(string userName, string password)
        {
            User user = AUTDataManager.GetUserByCredentials(userName, password);
            if (user != null)
            {
                List<Module> moduleList = AUTDataManager.GetModulesByRole(user.RoleId, user.BranchId);
                foreach (var module in moduleList)
                {
                    List<Feature> featureList = AUTDataManager.GetFeatureByRoleModule(user.RoleId, module.Id, user.BranchId);
                    module.Features = featureList;
                }

                user.Modules = moduleList;
            }
            return user;
        }


       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>


        public static List<User> GetUsers(int branchId)
        {
            return AUTDataManager.GetUsers(branchId);
        }

        public static bool DeleteUser(int userId)
        {
            return AUTDataManager.DeleteUser(userId);
        }

        public static int InsertOrUpdateUser(User user)
        {
            return AUTDataManager.InsertOrUpdateUser(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>

        public static List<UserRole> GetUserRoles(int branchId)
        {
            return AUTDataManager.GetUserRoles(branchId);
        }

        public static bool DeleteUserRole(int roleId)
        {
            return AUTDataManager.DeleteUserRole(roleId);
        }

        public static int InsertOrUpdateUserRole(UserRole role)
        {
            return AUTDataManager.InsertOrUpdateUserRole(role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>

        public static List<UserGroup> GetUserGroups(int branchId)
        {
            return AUTDataManager.GetUserGroups(branchId);
        }

        public static bool DeleteUserGroup(int groupId)
        {
            return AUTDataManager.DeleteUserGroup(groupId);
        }

        public static int InsertOrUpdateUserGroup(UserGroup group)
        {
            return AUTDataManager.InsertOrUpdateUserGroup(group);
        }

        public static List<Module> GetModulesByRole(int roleId, int branchId)
        {
            //return AUTDataManager.GetModulesByRole(roleId,branchId);

            List<Module> moduleList = AUTDataManager.GetModulesByRole(roleId, branchId);
            foreach (var module in moduleList)
            {
                List<Feature> featureList = AUTDataManager.GetFeatureByRoleModule(roleId, module.Id, branchId);
                module.Features = featureList;
            }

            return moduleList;
        }

        public static List<Operation> getOperations(int branchId)
        {
            return AUTDataManager.GetOperations(branchId);
        }

        public static bool AssignPermissions(List<Module> modules)
        {
            try
            {
                List<RolePrivilage> rolePrivilageList = new List<RolePrivilage>();
                for (int i = 0; i < modules.Count; i++)
                {
                    List<Feature> featureList = modules[i].Features;
                    for (int j = 0; j < featureList.Count; j++)
                    {
                        RolePrivilage rp = new RolePrivilage();
                        rp.ModuleId = modules[i].Id;
                        rp.BranchId = featureList[j].BranchId;
                        rp.RoleId = modules[i].RoleId;
                        rp.OperationId = featureList[j].Operation.Id; ;
                        rp.FeatureId = featureList[j].Id;
                        rp.IsDelete = featureList[j].IsActive? false:true;
                        rolePrivilageList.Add(rp);

                    }

                }
                for (int i = 0; i < rolePrivilageList.Count; i++)
                {
                    AUTDataManager.InsertOrUpdateRolePrivilage(rolePrivilageList[i]);
                }

                return true ; ;
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
