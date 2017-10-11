using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.DomainObjects
{
    public class ProcessCounter
    {
        public string MachineId { get; set; }
        public string CPUUsage { get; set; }
        public string RamUsage { get; set; }
        public List<MachineDriveInfo> DriverInfoList { get; set; }
    }
}
