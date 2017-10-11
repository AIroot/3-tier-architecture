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

namespace IOS.D2S.Data.KIOSKCommands.FileImportServiceActions
{
    public class InsertOrUpdateCheckInStatAction: IOSDBActionBase<int>
    {
        private readonly LogCheckInStat _logCheckInStat;

        public InsertOrUpdateCheckInStatAction(LogCheckInStat logCheckInStat)
        {
            _logCheckInStat = logCheckInStat;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateCheckInStat";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logCheckInStat.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logCheckInStat.MachineId));
                cmd.Parameters.Add(new SqlParameter("@bookingReference", _logCheckInStat.BookingReference));
                cmd.Parameters.Add(new SqlParameter("@reservationId", _logCheckInStat.ReservationId));
                cmd.Parameters.Add(new SqlParameter("@numberOfGuest", _logCheckInStat.NumberOfGuest));
                cmd.Parameters.Add(new SqlParameter("@timeSpent", _logCheckInStat.TimeSpent));
                cmd.Parameters.Add(new SqlParameter("@checkedInTime", _logCheckInStat.CheckedInTime));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logCheckInStat.IsDelete));
               

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
