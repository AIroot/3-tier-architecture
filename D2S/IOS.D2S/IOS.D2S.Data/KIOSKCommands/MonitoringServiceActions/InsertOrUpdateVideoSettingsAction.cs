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
    public class InsertOrUpdateVideoSettingsAction: IOSDBActionBase<int>
    {
        private readonly ConfigVideoSettings _configVideoSettings;

        public InsertOrUpdateVideoSettingsAction(ConfigVideoSettings configVideoSettings)
        {
            _configVideoSettings = configVideoSettings;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_STN_InsertOrUpdateVideoSettings";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _configVideoSettings.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _configVideoSettings.MachineId));
                cmd.Parameters.Add(new SqlParameter("@scanQRVideoPath", _configVideoSettings.ScanQRVideoPath));
                cmd.Parameters.Add(new SqlParameter("@scanPassportVideoPath", _configVideoSettings.ScanPassportVideoPath));
                cmd.Parameters.Add(new SqlParameter("@collectPassportVideoPath", _configVideoSettings.CollectPassportVideoPath));
                cmd.Parameters.Add(new SqlParameter("@insertCreditCardVideoPath", _configVideoSettings.InsertCreditCardVideoPath));
                cmd.Parameters.Add(new SqlParameter("@collectCreditCardVideoPath", _configVideoSettings.CollectCreditCardVideoPath));
                cmd.Parameters.Add(new SqlParameter("@enterPinVideoPath", _configVideoSettings.EnterPinVideoPath));
                cmd.Parameters.Add(new SqlParameter("@encodeKeyCardVideoPath", _configVideoSettings.EncodeKeyCardVideoPath));
                cmd.Parameters.Add(new SqlParameter("@collectKeyCardVideoPath", _configVideoSettings.CollectKeyCardVideoPath));
                cmd.Parameters.Add(new SqlParameter("@collectWelcomeNoteVideoPath", _configVideoSettings.CollectWelcomeNoteVideoPath));
                cmd.Parameters.Add(new SqlParameter("@insertKeyCardVideoPath", _configVideoSettings.InsertKeyCardVideoPath));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _configVideoSettings.IsDelete));
               

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