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
    public class InsertOrUpdateCheckOutStatAction: IOSDBActionBase<int>
    {
        private readonly LogCheckOutStat _logCheckOutStat;

        public InsertOrUpdateCheckOutStatAction(LogCheckOutStat logCheckOutStat)
        {
            _logCheckOutStat = logCheckOutStat;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateCheckOutStat";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logCheckOutStat.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logCheckOutStat.MachineId));
                cmd.Parameters.Add(new SqlParameter("@bookingReference", _logCheckOutStat.BookingReference));
                cmd.Parameters.Add(new SqlParameter("@reservationId", _logCheckOutStat.ReservationId));
                cmd.Parameters.Add(new SqlParameter("@numberOfGuest", _logCheckOutStat.NumberOfGuest));
                cmd.Parameters.Add(new SqlParameter("@timeSpent", _logCheckOutStat.TimeSpent));
                cmd.Parameters.Add(new SqlParameter("@checkedOutTime", _logCheckOutStat.CheckedOutTime));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logCheckOutStat.IsDelete));
               

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