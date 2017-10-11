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
    public class InsertOrUpdateDBSTransLogAction: IOSDBActionBase<int>
    {
        private readonly LogDBSTrans _logDBSTrans;

        public InsertOrUpdateDBSTransLogAction(LogDBSTrans logDBSTrans)
        {
            _logDBSTrans = logDBSTrans;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateDBSTransLog";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logDBSTrans.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logDBSTrans.MachineId));
                cmd.Parameters.Add(new SqlParameter("@tid", _logDBSTrans.TID));
                cmd.Parameters.Add(new SqlParameter("@mid", _logDBSTrans.MID));
                cmd.Parameters.Add(new SqlParameter("@batch", _logDBSTrans.Batch));
                cmd.Parameters.Add(new SqlParameter("@invoiceId", _logDBSTrans.InvoiceId));
                cmd.Parameters.Add(new SqlParameter("@pan", _logDBSTrans.PAN));
                cmd.Parameters.Add(new SqlParameter("@apCode", _logDBSTrans.APCode));
                cmd.Parameters.Add(new SqlParameter("@transDate", _logDBSTrans.TransDate));
                cmd.Parameters.Add(new SqlParameter("@card", _logDBSTrans.Card));
                cmd.Parameters.Add(new SqlParameter("@amount", _logDBSTrans.Amount));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logDBSTrans.IsDelete));
               

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
