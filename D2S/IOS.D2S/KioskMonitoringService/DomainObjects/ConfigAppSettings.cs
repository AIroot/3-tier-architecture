using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.DomainObjects
{
    public class ConfigAppSettings
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string AutoRunSlideShowTime { get; set; }
        public string IdleConfirmationLastingTime { get; set; }
        public string ScreenAutoTimeOut { get; set; }
        public string ApplicationStatisticLogPath { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegDate { get; set; }

    }
}
