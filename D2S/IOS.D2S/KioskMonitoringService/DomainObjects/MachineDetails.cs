using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.DomainObjects
{
    public class MachineDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }
        public string MachineUniqueId { get; set; }
        public int MachineGroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastResponseTime { get; set; }
        public string Ram { get; set; }
        public string CPU { get; set; }
        public string IPAddress { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }

        public MachineAppDetail MachineAppDetail { get; set; }
        public List<MachineDriveInfo> MachineDriveInfoList { get; set; }

        public ConfigAppSettings AppSettings { get; set; }
        public ConfigEmailSettings EmailSettings { get; set; }
        public ConfigHotelSettings HotelSettings { get; set; }
        public ConfigKeyServerSettings KeyServerSettings { get; set; }
        public ConfigPMSSettings ConfigPMSSettings { get; set; }
        public ConfigVideoSettings VideoSettings { get; set; }
    }
}
