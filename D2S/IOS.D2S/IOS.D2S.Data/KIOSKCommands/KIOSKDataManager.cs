using IOS.D2S.Core.DomainObjects;
using IOS.D2S.Data.KIOSKCommands.MonitoringServiceActions;
using IOS.D2S.DataConnector.DBFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Data.KIOSKCommands
{
    public class KIOSKDataManager
    {
        public static int InsertOrUpdateKIOSKMachineDetails(MachineDetails machineDetails)
        {
            try
            {
                InsertOrUpdateKIOSKMachineDetailsAction commd = new InsertOrUpdateKIOSKMachineDetailsAction(machineDetails);
                return commd.Execute(EnumDatabase.D2S);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
