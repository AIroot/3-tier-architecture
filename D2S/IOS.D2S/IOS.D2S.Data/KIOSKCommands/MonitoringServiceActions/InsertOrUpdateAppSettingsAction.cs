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
    public class InsertOrUpdateAppSettingsAction: IOSDBActionBase<int>
    {
        private readonly ConfigAppSettings _configAppSettings;

        public InsertOrUpdateAppSettingsAction(ConfigAppSettings configAppSettings)
        {
            _configAppSettings = configAppSettings;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_STN_InsertOrUpdateAppSettings";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _configAppSettings.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _configAppSettings.MachineId));
                cmd.Parameters.Add(new SqlParameter("@autoRunSlideShowTime", _configAppSettings.AutoRunSlideShowTime));
                cmd.Parameters.Add(new SqlParameter("@idleConfirmationLastingTime", _configAppSettings.IdleConfirmationLastingTime));
                cmd.Parameters.Add(new SqlParameter("@screenAutoTimeOut", _configAppSettings.ScreenAutoTimeOut));
                cmd.Parameters.Add(new SqlParameter("@applicationStatisticLogPath", _configAppSettings.ApplicationStatisticLogPath));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _configAppSettings.IsDelete));
               

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
