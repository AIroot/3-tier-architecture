using IOS.D2S.BL;
using IOS.D2S.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.API
{
    public class MonitoringServiceAPI
    {
        public static int InsertOrUpdateKIOSKMachineDetails(MachineDetails machineDetails)
        {
            return MonitoringServiceBL.InsertOrUpdateKIOSKMachineDetails(machineDetails);
        }
    }
}
