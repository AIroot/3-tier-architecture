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
    public class InsertOrUpdatePMSSettingsAction: IOSDBActionBase<int>
    {
        private readonly ConfigPMSSettings _configPMSSettings;

        public InsertOrUpdatePMSSettingsAction(ConfigPMSSettings configPMSSettings)
        {
            _configPMSSettings = configPMSSettings;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_STN_InsertOrUpdatePMSSettings";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _configPMSSettings.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _configPMSSettings.MachineId));
                cmd.Parameters.Add(new SqlParameter("@hotelID", _configPMSSettings.HotelID));
                cmd.Parameters.Add(new SqlParameter("@hotelChainID", _configPMSSettings.HotelChainID));
                cmd.Parameters.Add(new SqlParameter("@kioskID", _configPMSSettings.KioskID));
                cmd.Parameters.Add(new SqlParameter("@serviceUrl", _configPMSSettings.ServiceUrl));
                cmd.Parameters.Add(new SqlParameter("@userName", _configPMSSettings.UserName));
                cmd.Parameters.Add(new SqlParameter("@password", _configPMSSettings.Password));
                cmd.Parameters.Add(new SqlParameter("@serviceCallsLogPath", _configPMSSettings.ServiceCallsLogPath));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _configPMSSettings.IsDelete));
               

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