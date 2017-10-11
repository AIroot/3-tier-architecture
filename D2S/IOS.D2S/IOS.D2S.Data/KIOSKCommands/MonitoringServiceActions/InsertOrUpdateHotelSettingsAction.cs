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
    public class InsertOrUpdateHotelSettingsAction: IOSDBActionBase<int>
    {
        private readonly ConfigHotelSettings _configHotelSettings;

        public InsertOrUpdateHotelSettingsAction(ConfigHotelSettings configHotelSettings)
        {
            _configHotelSettings = configHotelSettings;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_STN_InsertOrUpdateHotelSettings";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _configHotelSettings.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _configHotelSettings.MachineId));
                cmd.Parameters.Add(new SqlParameter("@allowNextDayCheckIn", _configHotelSettings.AllowNextDayCheckIn));
                cmd.Parameters.Add(new SqlParameter("@officialCheckInTime", _configHotelSettings.OfficialCheckInTime));
                cmd.Parameters.Add(new SqlParameter("@officialCheckOutTime", _configHotelSettings.OfficialCheckOutTime));
                cmd.Parameters.Add(new SqlParameter("@checkInStartTime", _configHotelSettings.CheckInStartTime));
                cmd.Parameters.Add(new SqlParameter("@checkInEndTime", _configHotelSettings.CheckInEndTime));
                cmd.Parameters.Add(new SqlParameter("@wifiPassword", _configHotelSettings.WifiPassword));
                cmd.Parameters.Add(new SqlParameter("@hotelManagerName", _configHotelSettings.HotelManagerName));
                cmd.Parameters.Add(new SqlParameter("@hotelName", _configHotelSettings.HotelName));
                cmd.Parameters.Add(new SqlParameter("@hotelAddress", _configHotelSettings.HotelAddress));
                cmd.Parameters.Add(new SqlParameter("@paymentReceiptsMCPath", _configHotelSettings.PaymentReceiptsMCPath));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _configHotelSettings.IsDelete));
               

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