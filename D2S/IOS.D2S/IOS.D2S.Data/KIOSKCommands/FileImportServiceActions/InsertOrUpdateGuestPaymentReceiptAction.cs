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
    public class InsertOrUpdateGuestPaymentReceiptAction: IOSDBActionBase<int>
    {
        private readonly LogGuestPaymentReceipt _logGuestPaymentReceipt;

        public InsertOrUpdateGuestPaymentReceiptAction(LogGuestPaymentReceipt logGuestPaymentReceipt)
        {
            _logGuestPaymentReceipt = logGuestPaymentReceipt;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateGuestPaymentReceipt";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logGuestPaymentReceipt.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logGuestPaymentReceipt.MachineId));
                cmd.Parameters.Add(new SqlParameter("@logDate", _logGuestPaymentReceipt.LogDate));
                cmd.Parameters.Add(new SqlParameter("@bookingReference", _logGuestPaymentReceipt.BookingReference));
                cmd.Parameters.Add(new SqlParameter("@reservationId", _logGuestPaymentReceipt.ResevationId));
                cmd.Parameters.Add(new SqlParameter("@guestName", _logGuestPaymentReceipt.GuestName));
                cmd.Parameters.Add(new SqlParameter("@url", _logGuestPaymentReceipt.Url));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logGuestPaymentReceipt.IsDelete));
               

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