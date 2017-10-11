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
    public class InsertOrUpdateGuestScanImageAction: IOSDBActionBase<int>
    {
        private readonly LogGuestScanImage _logGuestScanImage;

        public InsertOrUpdateGuestScanImageAction(LogGuestScanImage logGuestScanImage)
        {
            _logGuestScanImage = logGuestScanImage;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateGuestScanImage";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logGuestScanImage.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logGuestScanImage.MachineId));
                cmd.Parameters.Add(new SqlParameter("@logDate", _logGuestScanImage.LogDate));
                cmd.Parameters.Add(new SqlParameter("@bookingReference", _logGuestScanImage.BookingReference));
                cmd.Parameters.Add(new SqlParameter("@reservationId", _logGuestScanImage.ResevationId));
                cmd.Parameters.Add(new SqlParameter("@documentId", _logGuestScanImage.DocumentId));
                cmd.Parameters.Add(new SqlParameter("@guestName", _logGuestScanImage.GuestName));
                cmd.Parameters.Add(new SqlParameter("@url", _logGuestScanImage.Url));
                cmd.Parameters.Add(new SqlParameter("@isSuccess", _logGuestScanImage.IsSuccess));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logGuestScanImage.IsDelete));
               

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