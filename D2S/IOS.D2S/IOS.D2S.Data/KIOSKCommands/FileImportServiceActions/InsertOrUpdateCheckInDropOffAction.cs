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
    public class InsertOrUpdateCheckInDropOffAction: IOSDBActionBase<int>
    {
        private readonly LogCheckInDropOff _logCheckInDropOff;

        public InsertOrUpdateCheckInDropOffAction(LogCheckInDropOff logCheckInDropOff)
        {
            _logCheckInDropOff = logCheckInDropOff;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateCheckInDropOff";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logCheckInDropOff.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logCheckInDropOff.MachineId));
                cmd.Parameters.Add(new SqlParameter("@reservationId", _logCheckInDropOff.ReservationId));
                cmd.Parameters.Add(new SqlParameter("@pageLeft", _logCheckInDropOff.PageLeft));
                cmd.Parameters.Add(new SqlParameter("@spentTime", _logCheckInDropOff.SpentTime));
                cmd.Parameters.Add(new SqlParameter("@logDateTime", _logCheckInDropOff.LogDateTime));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logCheckInDropOff.IsDelete));
               

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
