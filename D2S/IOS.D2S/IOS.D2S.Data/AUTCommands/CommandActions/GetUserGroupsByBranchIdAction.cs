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
    public class GetUserGroupsByBranchIdAction : IOSDBActionBase<List<UserGroup>>
    {
        private int _branchId = 0;
        public GetUserGroupsByBranchIdAction(int branchId)
        {
            _branchId = branchId;
        }
        protected override List<UserGroup> Body(System.Data.Common.DbConnection connection)
        {
            List<UserGroup> userGroupList = new List<UserGroup>();
            UserGroup userGroup = null;
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_GetUserGroups";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);
                cmd.Parameters.Add(new SqlParameter("@branchId", _branchId));

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userGroup = new UserGroup
                    {
                        Id = Convert.IsDBNull(reader["Id"]) ? 0 : Convert.ToInt32(reader["Id"]),
                        Name = Convert.IsDBNull(reader["Name"]) ? "" : reader["Name"].ToString(),
                        Description = Convert.IsDBNull(reader["Description"]) ? "" : reader["Description"].ToString(),
                        IsDelete = !Convert.IsDBNull(reader["IsDelete"]) && Convert.ToBoolean(reader["IsDelete"]),
                        BranchId = Convert.IsDBNull(reader["BranchId"]) ? 0 : Convert.ToInt32(reader["BranchId"])
                       
                    };

                    userGroupList.Add(userGroup);

                    
                }
            }
            catch (Exception ex)
            {
                FileLogger.Error("GetUserByCredentialsAction", ex);
                throw;
            }
            return userGroupList;
        }
    }
}
