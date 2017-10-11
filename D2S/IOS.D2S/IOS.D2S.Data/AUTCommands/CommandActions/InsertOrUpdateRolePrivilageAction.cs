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
    public class InsertOrUpdateRolePrivilageAction : IOSDBActionBase<bool>
    {
        private readonly RolePrivilage _rolePrivilage;

        public InsertOrUpdateRolePrivilageAction(RolePrivilage rolePrivilage)
        {
            _rolePrivilage = rolePrivilage;
        }

        protected override bool Body(DbConnection connection)
        {
            bool result =false;
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_InsertOrUpdateRolePrivilage";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@moduleId", _rolePrivilage.ModuleId));
                cmd.Parameters.Add(new SqlParameter("@featureId", _rolePrivilage.FeatureId));
                cmd.Parameters.Add(new SqlParameter("@operationId", _rolePrivilage.OperationId));
                cmd.Parameters.Add(new SqlParameter("@branchId", _rolePrivilage.BranchId));
                cmd.Parameters.Add(new SqlParameter("@roleId", _rolePrivilage.RoleId));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _rolePrivilage.IsDelete));
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                result = true;
            }


            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}

