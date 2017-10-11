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
    public class InsertOrUpdateUserRoleAction : IOSDBActionBase<int>
    {
        private readonly UserRole _role;

        public InsertOrUpdateUserRoleAction(UserRole role)
        {
            _role = role;
        }

        protected override int Body(DbConnection connection)
        {
            int roleId;
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_InsertOrUpdateUserRoles";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _role.Id));
                cmd.Parameters.Add(new SqlParameter("@name", _role.Name));
                cmd.Parameters.Add(new SqlParameter("@isActive", _role.IsActive));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _role.IsDelete));
                cmd.Parameters.Add(new SqlParameter("@canDeleteOrUpdate", _role.CanDeleteOrUpdate));
                cmd.Parameters.Add(new SqlParameter("@sortOrder", _role.SortOrder));
                cmd.Parameters.Add(new SqlParameter("@branchId", _role.BranchId));

                DbParameter outputParam = new SqlParameter();
                outputParam.DbType = DbType.Int32;
                outputParam.ParameterName = "@roleId";
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                roleId = outputParam.Value == null ? -1 : Convert.ToInt32(outputParam.Value);
            }
            catch (Exception)
            {
                throw;
            }
            return roleId;
        }
    }
}
