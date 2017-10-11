using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using KioskMonitoringService.Utils;
using KioskMonitoringService.DomainObjects;



namespace KioskMonitoringService.ServiceAgent
{
    public class ServiceWriter
    {
        private List<string> _param;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int InsertOrUpdateKIOSKMachineDetails(MachineDetails machineDetails)
        {
            try
            {
                _param = new List<string> { "InsertOrUpdateKIOSKMachineDetails" };
                WebRequest webRequest = StaticDataManager.GetWebRequest(_param, "POST", machineDetails);
                int response = StaticDataManager.GetWebResponse<int>(webRequest);
                return response;
            }
            catch (Exception ex)
            {
                log.Error("InsertOrUpdateKIOSKMachineDetails  :" + ex.Message + " : " + ex.InnerException);
                return -1;
            }
        }

        //public int AddNotification(NotificationEntity notification)
        //{
        //    try
        //    {
        //        _param = new List<string> { "AddNotification" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(_param, "POST", notification);
        //        int response = StaticDataManager.GetWebResponse<int>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("AddNotification  :" + ex.Message + " : " + ex.InnerException);
        //        return -1;
        //    }
        //}

        //public int AddUpdateDiskConsumption(List<DiskConsumptionEntity> diskConsumptionList)
        //{
        //    try
        //    {
        //        _param = new List<string> { "AddUpdateDiskConsumption" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(_param, "POST", diskConsumptionList);
        //        int response = StaticDataManager.GetWebResponse<int>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        FileLogger.EventLogWriter("AddUpdateDiskConsumption  :" + ex.Message + " : " + ex.InnerException);
        //        return -1;
        //    }
        //}

        //public int AddUpdateMemoryConsumption(List<MemoryConsumptionEntity> memoryConsumptionList)
        //{
        //    try
        //    {
        //        _param = new List<string> { "AddUpdateMemoryConsumption" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(_param, "POST", memoryConsumptionList);
        //        int response = StaticDataManager.GetWebResponse<int>(webRequest);

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        FileLogger.EventLogWriter("AddUpdateMemoryConsumption  :" + ex.Message + " : " + ex.InnerException);
        //        return -1;
        //    }
        //}

        //public int AddUpdateOperations(OperationsEntity operation)
        //{
        //    try
        //    {
        //        _param = new List<string> { "AddUpdateOperations" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(_param, "POST", operation);
        //        int response = StaticDataManager.GetWebResponse<int>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        FileLogger.EventLogWriter("AddUpdateOperations  :" + ex.Message + " : " + ex.InnerException);
        //        return -1;
        //    }
        //}

        //public int SaveOwsCalls(List<OWSCallEntity> owsCalls)
        //{
        //    try
        //    {
        //        _param = new List<string> { "SaveOwsCalls" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(_param, "POST", owsCalls);
        //        int response = StaticDataManager.GetWebResponse<int>(webRequest);

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        FileLogger.EventLogWriter("SaveOwsCalls  :" + ex.Message + " : " + ex.InnerException);
        //        return -1;
        //    }
        //}

        //public bool AddConfigurations(KioskConfigurationEntity kioskConfiguration)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> {"AddConfigurations"};
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(param, "POST", kioskConfiguration);
        //        bool response =StaticDataManager.GetWebResponse<bool>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        FileLogger.EventLogWriter("AddConfigurations  :" + ex.Message + " : " + ex.InnerException);
        //        return false;
        //    }
        //}

        //public string UploadFile(UploadFileInfo fileInfo)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "UploadFile" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(param, "POST", fileInfo);
        //        string response = StaticDataManager.GetWebResponse<string>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        FileLogger.EventLogWriter("UploadFile  :" + ex.Message + " : " + ex.InnerException);
        //        return string.Empty;
        //    }
        //}

        

        //public bool UpdateGeustProfileDataToDatabase(UploadFileInfo fileInfo)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "UpdateGeustProfileDataToDatabase" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(param, "POST", fileInfo);
        //        bool response = StaticDataManager.GetWebResponse<bool>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {

        //        FileLogger.EventLogWriter("UpdateGeustProfileDataToDatabase  :" + ex.Message + " : " + ex.InnerException);
        //        return false;
        //    }
           
        //}

        //public int UpdateMachineStatus(MachineDetailsEntity machineDetails)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "UpdateMachineStatus" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(param, "POST", machineDetails);
        //        int response = StaticDataManager.GetWebResponse<int>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {

        //        FileLogger.EventLogWriter("UpdateMachineStatus  :" + ex.Message + " : " + ex.InnerException);
        //        return -1;
        //    }
          
        //}

        //public bool UpdateApplicationStatus(AppDetailsEntity applicationDetails)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "UpdateApplicationStatus" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(param, "POST", applicationDetails);
        //        bool response = StaticDataManager.GetWebResponse<bool>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {

        //        FileLogger.EventLogWriter("UpdateApplicationStatus  :" + ex.Message + " : " + ex.InnerException);
        //        return false;
        //    }
          
        //}

       
    }
}
