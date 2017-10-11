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
    public class DeleteUserByUserIdAction : IOSDBActionBase<bool>
    {
        private readonly int _userId;

        public DeleteUserByUserIdAction(int userId)
        {
            _userId = userId;
        }

        protected override bool Body(DbConnection connection)
        {
            try
            {
                const string storedProcedureName = "dbo.D2S_AUT_DeleteUser";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _userId));
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
