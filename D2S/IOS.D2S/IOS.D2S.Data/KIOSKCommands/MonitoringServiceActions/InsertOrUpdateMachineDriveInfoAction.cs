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
    public class InsertOrUpdateMachineDriveInfoAction :IOSDBActionBase<int>
    {
        private readonly MachineDriveInfo _machineDriveInfo;

        public InsertOrUpdateMachineDriveInfoAction(MachineDriveInfo machineDriveInfo)
        {
            _machineDriveInfo = machineDriveInfo;
        }

        protected override int Body(DbConnection connection)
        {
            int outPutId;
            try
            {
                const string storedProcedureName = "dbo.D2S_MID_InsertOrUpdateMachineDriveInfo";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _machineDriveInfo.Id));
                cmd.Parameters.Add(new SqlParameter("@machineId", _machineDriveInfo.MachineId));
                cmd.Parameters.Add(new SqlParameter("@driverName", _machineDriveInfo.DriverName));
                cmd.Parameters.Add(new SqlParameter("@usedSpace", _machineDriveInfo.UsedSpace));
                cmd.Parameters.Add(new SqlParameter("@freeSpace", _machineDriveInfo.FreeSpace));
                cmd.Parameters.Add(new SqlParameter("@totalSize", _machineDriveInfo.TotalSize));
               
               

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