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
    public class InsertOrUpdateDevicesStatAction: IOSDBActionBase<int>
    {
        private readonly LogDevicesStat _logDevicesStat;

        public InsertOrUpdateDevicesStatAction(LogDevicesStat logDevicesStat)
        {
            _logDevicesStat = logDevicesStat;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_LOG_InsertOrUpdateDevicesStat";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _logDevicesStat.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _logDevicesStat.MachineId));
                cmd.Parameters.Add(new SqlParameter("@device", _logDevicesStat.Device));
                cmd.Parameters.Add(new SqlParameter("@status", _logDevicesStat.Status));
                cmd.Parameters.Add(new SqlParameter("@message", _logDevicesStat.Message));
                cmd.Parameters.Add(new SqlParameter("@loggedTime", _logDevicesStat.LoggedTime));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _logDevicesStat.IsDelete));
               

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