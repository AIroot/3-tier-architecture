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
    public class InsertOrUpdateGuestScanDataAction: IOSDBActionBase<int>
    {
        private readonly LogGuestScanData _logGuestScanData;

        public InsertOrUpdateGuestScanDataAction(LogGuestScanData logGuestScanData)
        {
            _logGuestScanData = logGuestScanData;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateGuestScanData";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logGuestScanData.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logGuestScanData.MachineId));
                cmd.Parameters.Add(new SqlParameter("@profileId", _logGuestScanData.ProfileId));
                cmd.Parameters.Add(new SqlParameter("@profileCode", _logGuestScanData.ProfileCode));
                cmd.Parameters.Add(new SqlParameter("@salutation", _logGuestScanData.Salutation));
                cmd.Parameters.Add(new SqlParameter("@fullName", _logGuestScanData.FullName));
                cmd.Parameters.Add(new SqlParameter("@documentType", _logGuestScanData.DocumentType));
                cmd.Parameters.Add(new SqlParameter("@documentNumber", _logGuestScanData.DocumentId));
                cmd.Parameters.Add(new SqlParameter("@email", _logGuestScanData.Email));
                cmd.Parameters.Add(new SqlParameter("@mobile", _logGuestScanData.Mobile));
                cmd.Parameters.Add(new SqlParameter("@occupation", _logGuestScanData.Occupation));
                cmd.Parameters.Add(new SqlParameter("@placeOfEmployment", _logGuestScanData.PlaceOfEmployment));
                cmd.Parameters.Add(new SqlParameter("@lastCountryEmbarkation", _logGuestScanData.LastCountryEmbarkation));
                cmd.Parameters.Add(new SqlParameter("@lastCountryEmbarkationAddr", _logGuestScanData.LastCountryEmbarkationAddr));
                cmd.Parameters.Add(new SqlParameter("@nextDestination", _logGuestScanData.NextDestination));
                cmd.Parameters.Add(new SqlParameter("@bookingReference", _logGuestScanData.BookingReference));
                cmd.Parameters.Add(new SqlParameter("@documentId", _logGuestScanData.DocumentId));
                cmd.Parameters.Add(new SqlParameter("@reservationId", _logGuestScanData.ReservationId));
                cmd.Parameters.Add(new SqlParameter("@url", _logGuestScanData.Url));
                cmd.Parameters.Add(new SqlParameter("@logDate", _logGuestScanData.LogDate));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logGuestScanData.IsDelete));
               

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