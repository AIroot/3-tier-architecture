using IOS.D2S.API;
using IOS.D2S.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IOS.D2S.WebAPI.Controllers
{
    public class MonitoringServiceController : ApiController
    {
        [HttpPost]
        public int  InsertOrUpdateKIOSKMachineDetails(MachineDetails machineDetails)
        {
            return MonitoringServiceAPI.InsertOrUpdateKIOSKMachineDetails(machineDetails);
        }
    }
}
