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
    public class GetModulesByRoleAction: IOSDBActionBase<List<Module>>
    {
        private int _roleId = -1;

        private int _branchId = -1;
        public GetModulesByRoleAction(int roleId,  int branchId)
        {
            _roleId = roleId;
            _branchId = branchId;
        }
        protected override List<Module> Body(System.Data.Common.DbConnection connection)
        {
            List<Module> moduleList = new List<Module>();
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_GetModulesByRole";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(new SqlParameter("@RoleId", _roleId));
                cmd.Parameters.Add(new SqlParameter("@BranchId", _branchId));

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Module feature = new Module()
                    {
                        Id = Convert.IsDBNull(reader["Id"]) ? 0 : Convert.ToInt32(reader["Id"]),
                        DisplayName = Convert.IsDBNull(reader["Name"]) ? "" : reader["Name"].ToString(),
                        Name = Convert.IsDBNull(reader["Name"]) ? "" : reader["Name"].ToString(),
                        IsActive = !Convert.IsDBNull(reader["IsActive"]) && Convert.ToBoolean(reader["IsActive"]),
                        IsDelete = !Convert.IsDBNull(reader["IsDelete"]) && Convert.ToBoolean(reader["IsDelete"]),
                         
                        ImageUrl = Convert.IsDBNull(reader["ImageUrl"]) ? "" : reader["ImageUrl"].ToString(),
                        NavigationUrl = Convert.IsDBNull(reader["NavigationUrl"]) ? "" : reader["NavigationUrl"].ToString(),

                        SortOrder = Convert.IsDBNull(reader["SortOrder"]) ? 0 : Convert.ToInt32(reader["SortOrder"]),
                        BranchId = Convert.IsDBNull(reader["BranchId"]) ? 0 : Convert.ToInt32(reader["BranchId"]),
                       
                      
                       
                    };

                    moduleList.Add(feature);

                    
                }
            }
            catch (Exception ex)
            {
                FileLogger.Error("GetModulesByRoleAction", ex);
                throw;
            }
            return moduleList;
        }
    }
}

