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
    public class InsertOrUpdateGuestArrivalFormAction: IOSDBActionBase<int>
    {
        private readonly LogGuestArrivalForm _logGuestArrivalForm;

        public InsertOrUpdateGuestArrivalFormAction(LogGuestArrivalForm logGuestArrivalForm)
        {
            _logGuestArrivalForm = logGuestArrivalForm;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateGuestArrivalForm";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logGuestArrivalForm.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logGuestArrivalForm.MachineId));
                cmd.Parameters.Add(new SqlParameter("@logDate", _logGuestArrivalForm.LogDate));
                cmd.Parameters.Add(new SqlParameter("@bookingReference", _logGuestArrivalForm.BookingReference));
                cmd.Parameters.Add(new SqlParameter("@reservationId", _logGuestArrivalForm.ResevationId));
                cmd.Parameters.Add(new SqlParameter("@guestName", _logGuestArrivalForm.GuestName));
                cmd.Parameters.Add(new SqlParameter("@url", _logGuestArrivalForm.Url));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logGuestArrivalForm.IsDelete));
               

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