using IOS.D2S.API;
using IOS.D2S.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IOS.D2S.WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        public User GetUserByCredentials(Credential credential)
        {
            return AuthAPI.GetUserByCredentials(credential.UserName, credential.Password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>

        [HttpGet]
        public List<User> GetUsers(int branchId)
        {
            return AuthAPI.GetUsers(branchId);
        }

        [HttpPost]
        public bool DeleteUser(User user)
        {
            return AuthAPI.DeleteUser(user.Id);
        }

        [HttpPost]
        public int InsertOrUpdateUser(User user)
        {
            return AuthAPI.InsertOrUpdateUser(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>

        [HttpGet]
        public List<UserRole> GetUserRoles(int branchId)
        {
            return AuthAPI.GetUserRoles(branchId);
        }

        [HttpPost]
        public bool DeleteUserRole(UserRole role)
        {
            return AuthAPI.DeleteUserRole(role.Id);
        }

        [HttpPost]
        public int InsertOrUpdateUserRole(UserRole role)
        {
            return AuthAPI.InsertOrUpdateUserRole(role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        /// 

        [HttpGet]
        public List<UserGroup> GetUserGroups(int branchId)
        {
            return AuthAPI.GetUserGroups(branchId);
        }

        [HttpPost]
        public bool DeleteUserGroup(UserGroup group)
        {
            return AuthAPI.DeleteUserGroup(group.Id);
        }

        [HttpPost]
        public int InsertOrUpdateUserGroup(UserGroup group)
        {
            return AuthAPI.InsertOrUpdateUserGroup(group);
        }

        [HttpGet]
        public List<Module> GetModulesByRole(int roleId, int branchId)
        {
            
            return AuthAPI.GetModulesByRole(roleId, branchId);
        }

        [HttpGet]
        public List<Operation> GetOperations(int branchId)
        {

            return AuthAPI.getOperations(branchId);
        }

        [HttpPost]
        public bool AssignPermissions(AssignRolePrivilegeRequest rolePrivilegeRequest)
        {

            return AuthAPI.AssignPermissions(rolePrivilegeRequest.moduleList);
        }
    }
}
