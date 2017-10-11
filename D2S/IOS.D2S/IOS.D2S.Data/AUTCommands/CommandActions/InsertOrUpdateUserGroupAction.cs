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
    public class InsertOrUpdateUserGroupAction : IOSDBActionBase<int>
    {
        private readonly UserGroup _group;

        public InsertOrUpdateUserGroupAction(UserGroup group)
        {
            _group = group;
        }

        protected override int Body(DbConnection connection)
        {
            int groupId;
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_InsertOrUpdateUserGroup";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _group.Id));
                cmd.Parameters.Add(new SqlParameter("@name", _group.Name));
                cmd.Parameters.Add(new SqlParameter("@isActive", _group.Description));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _group.IsDelete));
                cmd.Parameters.Add(new SqlParameter("@branchId", _group.BranchId));

                DbParameter outputParam = new SqlParameter();
                outputParam.DbType = DbType.Int32;
                outputParam.ParameterName = "@groupId";
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                groupId = outputParam.Value == null ? -1 : Convert.ToInt32(outputParam.Value);
            }
            catch (Exception)
            {
                throw;
            }
            return groupId;
        }
    }
}
