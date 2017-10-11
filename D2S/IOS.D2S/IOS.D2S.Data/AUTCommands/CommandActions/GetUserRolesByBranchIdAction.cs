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
    public class GetUserRolesByBranchIdAction : IOSDBActionBase<List<UserRole>>
    {
        private int _branchId = 0;
        public GetUserRolesByBranchIdAction(int branchId)
        {
            _branchId = branchId;
        }
        protected override List<UserRole> Body(System.Data.Common.DbConnection connection)
        {

            List<UserRole> roleList = new List<UserRole>();
            UserRole role = null;
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_GetUserRoles";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(new SqlParameter("@branchId", _branchId));

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    role = new UserRole
                    {
                        Id = Convert.IsDBNull(reader["Id"]) ? 0 : Convert.ToInt32(reader["Id"]),
                        Name = Convert.IsDBNull(reader["Name"]) ? "" : reader["Name"].ToString(),
                        CanDeleteOrUpdate = !Convert.IsDBNull(reader["CanDeleteOrUpdate"]) && Convert.ToBoolean(reader["CanDeleteOrUpdate"]),
                        IsActive = !Convert.IsDBNull(reader["IsActive"]) && Convert.ToBoolean(reader["IsActive"]),
                        IsDelete = !Convert.IsDBNull(reader["IsDelete"]) && Convert.ToBoolean(reader["IsDelete"]),
                        SortOrder = Convert.IsDBNull(reader["SortOrder"]) ? 0 : Convert.ToInt32(reader["SortOrder"]),
                        BranchId = Convert.IsDBNull(reader["BranchId"]) ? 0 : Convert.ToInt32(reader["BranchId"])
                       
                    };

                    roleList.Add(role);

                    
                }
            }
            catch (Exception ex)
            {
                FileLogger.Error("GetUserByCredentialsAction", ex);
                throw;
            }
            return roleList;
        }
    }
}
