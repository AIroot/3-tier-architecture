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
    public class DeleteUserRoleByRoleIdAction : IOSDBActionBase<bool>
    {
        private readonly int _roleId;

        public DeleteUserRoleByRoleIdAction(int roleId)
        {
            _roleId = roleId;
        }

        protected override bool Body(DbConnection connection)
        {
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_DeleteUserRole";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _roleId));
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
