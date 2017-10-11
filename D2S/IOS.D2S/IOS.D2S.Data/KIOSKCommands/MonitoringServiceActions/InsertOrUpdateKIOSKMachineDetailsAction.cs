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
    public class InsertOrUpdateKIOSKMachineDetailsAction: IOSDBActionBase<int>
    {
        private readonly MachineDetails _machineDetails;

        public InsertOrUpdateKIOSKMachineDetailsAction(MachineDetails machineDetails)
        {
            _machineDetails = machineDetails;
        }

        protected override int Body(DbConnection connection)
        {
            int machineId;
            try
            {
                const string storedProcedureName = "dbo.D2S_MID_InsertOrUpdateMachineDetail";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                cmd.Parameters.Add(new SqlParameter("@id", _machineDetails.Id));
                cmd.Parameters.Add(new SqlParameter("@branchId", _machineDetails.BranchId));
                cmd.Parameters.Add(new SqlParameter("@machineGroupId", _machineDetails.MachineGroupId));
                cmd.Parameters.Add(new SqlParameter("@name", _machineDetails.Name));
                cmd.Parameters.Add(new SqlParameter("@machineUniqueId", _machineDetails.MachineUniqueId));
                cmd.Parameters.Add(new SqlParameter("@startDate", _machineDetails.StartDate));
                cmd.Parameters.Add(new SqlParameter("@endDate", _machineDetails.EndDate));
                cmd.Parameters.Add(new SqlParameter("@lastResponseTime", _machineDetails.LastResponseTime));
                cmd.Parameters.Add(new SqlParameter("@ram", _machineDetails.Ram));
                cmd.Parameters.Add(new SqlParameter("@cpu", _machineDetails.CPU));
                cmd.Parameters.Add(new SqlParameter("@ipAddress", _machineDetails.IPAddress));
                cmd.Parameters.Add(new SqlParameter("@isDefault", _machineDetails.IsDefault));
                cmd.Parameters.Add(new SqlParameter("@isActive", _machineDetails.IsActive));
                cmd.Parameters.Add(new SqlParameter("@isDelete", _machineDetails.IsDelete));

                DbParameter outputParam = new SqlParameter();
                outputParam.DbType = DbType.Int32;
                outputParam.ParameterName = "@outPutId";
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                machineId = outputParam.Value == null ? -1 : Convert.ToInt32(outputParam.Value);

                if (_machineDetails.AppSettings != null && machineId>0)
                {
                    _machineDetails.AppSettings.MachineId = machineId;
                    int appSettingId = new InsertOrUpdateAppSettingsAction(_machineDetails.AppSettings).Execute(EnumDatabase.D2S);
                }

                if (_machineDetails.ConfigPMSSettings != null && machineId > 0)
                {
                    _machineDetails.ConfigPMSSettings.MachineId = machineId;
                    int pmsSettingId = new InsertOrUpdatePMSSettingsAction(_machineDetails.ConfigPMSSettings).Execute(EnumDatabase.D2S);
                }
                if (_machineDetails.EmailSettings != null && machineId > 0)
                {
                    _machineDetails.EmailSettings.MachineId = machineId;
                    int emailSettingId = new InsertOrUpdateEmailSettingsAction(_machineDetails.EmailSettings).Execute(EnumDatabase.D2S);
                }
                if (_machineDetails.HotelSettings != null && machineId > 0)
                {
                    _machineDetails.HotelSettings.MachineId = machineId;
                    int hotelSettingId = new InsertOrUpdateHotelSettingsAction(_machineDetails.HotelSettings).Execute(EnumDatabase.D2S);
                }

                if (_machineDetails.KeyServerSettings != null && machineId > 0)
                {
                    _machineDetails.KeyServerSettings.MachineId = machineId;
                    int keyServerSettingId = new InsertOrUpdateRoomKeyServerSettingsAction(_machineDetails.KeyServerSettings).Execute(EnumDatabase.D2S);
                }

                if (_machineDetails.VideoSettings != null && machineId > 0)
                {
                    _machineDetails.VideoSettings.MachineId = machineId;
                    int keyServerSettingId = new InsertOrUpdateVideoSettingsAction(_machineDetails.VideoSettings).Execute(EnumDatabase.D2S);
                }

                if (_machineDetails.MachineAppDetail != null && machineId > 0)
                {

                    _machineDetails.MachineAppDetail.MachineId = machineId;
                    int appDetailId = new InsertOrUpdateMachineAppDetailAction(_machineDetails.MachineAppDetail).Execute(EnumDatabase.D2S);
                }

                if (_machineDetails.MachineDriveInfoList != null && machineId > 0)
                {
                    for (int i = 0; i < _machineDetails.MachineDriveInfoList.Count; i++)
                    {
                        _machineDetails.MachineDriveInfoList[i].MachineId = machineId;
                        int driveInfoId = new InsertOrUpdateMachineDriveInfoAction(_machineDetails.MachineDriveInfoList[i]).Execute(EnumDatabase.D2S);
                    }
                    
                }



            }
            catch (Exception ex)
            {
                throw;
            }
            return machineId;
        }
    }
}
