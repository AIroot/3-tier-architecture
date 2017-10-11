using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class ConfigPMSSettings
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string HotelID { get; set; }
        public string HotelChainID { get; set; }
        public string KioskID { get; set; }
        public string ServiceUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServiceCallsLogPath { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegDate { get; set; }
    }
}
