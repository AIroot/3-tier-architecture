using System;
using System.Collections.Generic;
using System.Net;

namespace KioskMonitoringService.ServiceAgent
{
    public class ServiceReader
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
   (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //public List<OperationsEntity> GetDailyOperationsList(MachineOperationParameters parameters)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "GetDailyOperationsList" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest(param, "POST", parameters);
        //        List<OperationsEntity> response = StaticDataManager.GetWebResponse<List<OperationsEntity>>(webRequest);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        //public List<NotificationTypeEntity> GetNotificationType()
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "GetNotificationType" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest<object>(param, "GET");
        //        return StaticDataManager.GetWebResponse<List<NotificationTypeEntity>>(webRequest, "GetNotificationType");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        //public MachineDetailsEntity GetMachineGroupByMachineId(string machineId)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "GetMachineGroupByMachineId", machineId };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest<object>(param, "GET");
        //        MachineDetailsEntity response = StaticDataManager.GetWebResponse<MachineDetailsEntity>(webRequest, "GetMachineGroupByMachineId");
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        //public List<StatusTypeEntity> GetStatusType()
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "GetStatusType" };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest<object>(param, "GET");
        //        return StaticDataManager.GetWebResponse<List<StatusTypeEntity>>(webRequest, "GetStatusType");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        //public KioskConfigurationEntity GetKioskConfiguration(string kioskId)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "GetConfigurationById", kioskId };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest<object>(param, "GET");
        //        return StaticDataManager.GetWebResponse<KioskConfigurationEntity>(webRequest);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}


        //public bool ShedluledProfileOperations(string machineId)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "ShedluledProfileOperations", machineId };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest<object>(param, "GET");
        //        return StaticDataManager.GetWebResponse<bool>(webRequest);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
           
        //}
        //public bool SheduledNextOperation(int operationId)
        //{
        //    try
        //    {
        //        List<string> param = new List<string> { "SheduledNextOperation", operationId.ToString() };
        //        WebRequest webRequest = StaticDataManager.GetWebRequest<object>(param, "GET");
        //        return StaticDataManager.GetWebResponse<bool>(webRequest);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
          
        //}

    }
}
