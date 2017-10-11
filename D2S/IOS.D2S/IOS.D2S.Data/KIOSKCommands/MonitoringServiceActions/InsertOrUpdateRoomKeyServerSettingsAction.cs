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

namespace IOS.D2S.Data.KIOSKCommands.MonitoringServiceActions
{
    public class InsertOrUpdateRoomKeyServerSettingsAction: IOSDBActionBase<int>
    {
        private readonly ConfigKeyServerSettings _configKeyServerSettings;

        public InsertOrUpdateRoomKeyServerSettingsAction(ConfigKeyServerSettings configKeyServerSettings)
        {
            _configKeyServerSettings = configKeyServerSettings;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_STN_InsertOrUpdatePMSSettings";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _configKeyServerSettings.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _configKeyServerSettings.MachineId));
                cmd.Parameters.Add(new SqlParameter("@saflokServerIP", _configKeyServerSettings.SaflokServerIP));
                cmd.Parameters.Add(new SqlParameter("@saflokServerPort", _configKeyServerSettings.SaflokServerPort));
                cmd.Parameters.Add(new SqlParameter("@keyExpirationTime", _configKeyServerSettings.KeyExpirationTime));
                cmd.Parameters.Add(new SqlParameter("@encoderNumber", _configKeyServerSettings.EncoderNumber));
                cmd.Parameters.Add(new SqlParameter("@pmsTerminalNumber", _configKeyServerSettings.PMSTerminalNumber));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _configKeyServerSettings.IsDelete));
               

                DbParameter outputParam = new SqlParameter();
                outputParam.DbType = DbType.Int32;
                outputParam.ParameterName = "@outPutId";
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                outPutId = outputParam.Value == null ? -1 : Convert.ToInt32(outputParam.Value);

             
            }
            catch (Exception)
            {
                throw;
            }
            return outPutId;
        }
    }
}