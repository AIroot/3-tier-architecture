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
    public class InsertOrUpdateEmailSettingsAction: IOSDBActionBase<int>
    {
        private readonly ConfigEmailSettings _configEmailSettings;

        public InsertOrUpdateEmailSettingsAction(ConfigEmailSettings configEmailSettings)
        {
            _configEmailSettings = configEmailSettings;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_STN_InsertOrUpdateEmailSettings";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _configEmailSettings.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _configEmailSettings.MachineId));
                cmd.Parameters.Add(new SqlParameter("@smtpServer", _configEmailSettings.SMTPServer));
                cmd.Parameters.Add(new SqlParameter("@smtpPort", _configEmailSettings.SMTPPort));
                cmd.Parameters.Add(new SqlParameter("@smtpUserName", _configEmailSettings.SMTPUserName));
                cmd.Parameters.Add(new SqlParameter("@smtpPassword", _configEmailSettings.SMTPPassword));
                cmd.Parameters.Add(new SqlParameter("@fromEmail", _configEmailSettings.FromEmail));
                cmd.Parameters.Add(new SqlParameter("@bccEmailsInvoices", _configEmailSettings.BCCEmailsInvoices));
                cmd.Parameters.Add(new SqlParameter("@toNotificationEmail", _configEmailSettings.ToNotificationEmail));
                cmd.Parameters.Add(new SqlParameter("@ccEmailsNotifications", _configEmailSettings.CCEmailsNotifications));
                cmd.Parameters.Add(new SqlParameter("@failScannedToEmails", _configEmailSettings.FailScannedToEmails));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _configEmailSettings.IsDelete));
               

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