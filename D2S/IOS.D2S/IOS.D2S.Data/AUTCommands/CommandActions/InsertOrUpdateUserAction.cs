using IOS.D2S.Core.DomainObjects;
using IOS.D2S.DataConnector.DBFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Data.AUTCommands.CommandActions
{
    public class InsertOrUpdateUserAction : IOSDBActionBase<int>
    {
        private readonly User _user;

        public InsertOrUpdateUserAction(User user)
        {
            _user = user;
        }

        protected override int Body(DbConnection connection)
        {
            int userId;
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_InsertOrUpdateUser";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _user.Id));
                cmd.Parameters.Add(new SqlParameter("@employeeNo", _user.EmployeeNo));
                cmd.Parameters.Add(new SqlParameter("@firstName", _user.FirstName));
                cmd.Parameters.Add(new SqlParameter("@lastName", _user.LastName));
                cmd.Parameters.Add(new SqlParameter("@isActive", _user.IsActive));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _user.IsDelete));
                cmd.Parameters.Add(new SqlParameter("@imageUrl", _user.ImageUrl));
                cmd.Parameters.Add(new SqlParameter("@sortOrder", _user.SortOrder));
                cmd.Parameters.Add(new SqlParameter("@gender", _user.Gender));
                cmd.Parameters.Add(new SqlParameter("@dateOfBirth", _user.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@joinDate", _user.JoinDate));
                cmd.Parameters.Add(new SqlParameter("@username", _user.Username));
                cmd.Parameters.Add(new SqlParameter("@password", _user.Password));
                cmd.Parameters.Add(new SqlParameter("@remark", _user.Remark));
                cmd.Parameters.Add(new SqlParameter("@roleId", _user.RoleId));
                cmd.Parameters.Add(new SqlParameter("@branchId", _user.BranchId));

                DbParameter outputParam = new SqlParameter();
                outputParam.DbType = DbType.Int32;
                outputParam.ParameterName = "@userId";
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                userId = outputParam.Value == null ? -1 : Convert.ToInt32(outputParam.Value);
            }
            catch (Exception)
            {
                throw;
            }
            return userId;
        }
    }
}
