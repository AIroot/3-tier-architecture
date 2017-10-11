using IOS.D2S.Core.DomainObjects;
using IOS.D2S.Data.KIOSKCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.BL
{
    public class MonitoringServiceBL
    {
        public static int InsertOrUpdateKIOSKMachineDetails(MachineDetails machineDetails)
        {
            return KIOSKDataManager.InsertOrUpdateKIOSKMachineDetails(machineDetails);
        }
       
    }
}
