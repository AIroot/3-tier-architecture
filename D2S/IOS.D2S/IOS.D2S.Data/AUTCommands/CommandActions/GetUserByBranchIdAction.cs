using IOS.D2S.Core.DomainObjects;
using IOS.D2S.Core.Utils;
using IOS.D2S.DataConnector.DBFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Data.AUTCommands.CommandActions
{
    public class GetUserByBranchIdAction : IOSDBActionBase<List<User>>
    {
        private int _branchId = 0;
        public GetUserByBranchIdAction(int branchId)
        {
            _branchId = branchId;
        }
        protected override List<User> Body(System.Data.Common.DbConnection connection)
        {
            List<User> users = new List<User>();
            User user = null;
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_GetUsers";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(new SqlParameter("@branchId", _branchId));

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.IsDBNull(reader["Id"]) ? 0 : Convert.ToInt32(reader["Id"]),
                        FirstName = Convert.IsDBNull(reader["FirstName"]) ? "" : reader["FirstName"].ToString(),
                        LastName = Convert.IsDBNull(reader["LastName"]) ? "" : reader["LastName"].ToString(),
                        IsActive = !Convert.IsDBNull(reader["IsActive"]) && Convert.ToBoolean(reader["IsActive"]),
                        IsDelete = !Convert.IsDBNull(reader["IsDelete"]) && Convert.ToBoolean(reader["IsDelete"]),
                        EmployeeNo = Convert.IsDBNull(reader["EmployeeNo"]) ? "" : reader["EmployeeNo"].ToString(),
                        Gender = Convert.IsDBNull(reader["Gender"]) ? "" : reader["Gender"].ToString(),
                        DateOfBirth = Convert.IsDBNull(reader["DateOfBirth"]) ? DateTime.Today : Convert.ToDateTime(reader["DateOfBirth"]),
                        ImageUrl = Convert.IsDBNull(reader["ImageUrl"]) ? "" : reader["ImageUrl"].ToString(),
                        SortOrder = Convert.IsDBNull(reader["SortOrder"]) ? 0 : Convert.ToInt32(reader["SortOrder"]),
                        JoinDate = Convert.IsDBNull(reader["JoinDate"]) ? DateTime.Today : Convert.ToDateTime(reader["JoinDate"]),
                        Username = Convert.IsDBNull(reader["Username"]) ? "" : reader["Username"].ToString(),
                        Password = Convert.IsDBNull(reader["Password"]) ? "" : reader["Password"].ToString(),
                        Remark = Convert.IsDBNull(reader["Remark"]) ? "" : reader["Remark"].ToString(),
                        BranchId = Convert.IsDBNull(reader["BranchId"]) ? 0 : Convert.ToInt32(reader["BranchId"]),
                       
                        IsSystemUser = !Convert.IsDBNull(reader["IsSystemUser"]) && Convert.ToBoolean(reader["IsSystemUser"]),
                       
                    };
                    users.Add(user);
                    
                }
            }
            catch (Exception ex)
            {
                FileLogger.Error("GetUserByCredentialsAction", ex);
                throw;
            }
            return users;
        }

    }
}
