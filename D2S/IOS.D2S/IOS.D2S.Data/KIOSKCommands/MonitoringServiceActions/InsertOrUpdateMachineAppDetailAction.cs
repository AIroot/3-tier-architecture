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
    public class InsertOrUpdateMachineAppDetailAction: IOSDBActionBase<int>
    {
        private readonly MachineAppDetail _machineAppDetail;

        public InsertOrUpdateMachineAppDetailAction(MachineAppDetail machineAppDetail)
        {
            _machineAppDetail = machineAppDetail;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_MID_InsertOrUpdateMachineAppDetai";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _machineAppDetail.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _machineAppDetail.MachineId));
                cmd.Parameters.Add(new SqlParameter("@name", _machineAppDetail.Name));
                cmd.Parameters.Add(new SqlParameter("@version", _machineAppDetail.Version));
                cmd.Parameters.Add(new SqlParameter("@startDate", _machineAppDetail.StartDate));
                cmd.Parameters.Add(new SqlParameter("@endDate", _machineAppDetail.EndDate));
                cmd.Parameters.Add(new SqlParameter("@currentStatus", _machineAppDetail.CurrentStatus));
                cmd.Parameters.Add(new SqlParameter("@lastResponseTime", _machineAppDetail.LastResponseTime));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _machineAppDetail.IsDelete));
               

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