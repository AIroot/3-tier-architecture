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
    public class DeleteUserGroupByGroupIdAction : IOSDBActionBase<bool>
    {
        private readonly int _groupId;

        public DeleteUserGroupByGroupIdAction(int groupId)
        {
            _groupId = groupId;
        }

        protected override bool Body(DbConnection connection)
        {
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_DeleteUserGroup";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _groupId));
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
