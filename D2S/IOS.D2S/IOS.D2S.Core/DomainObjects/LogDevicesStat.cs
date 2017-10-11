using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class LogDevicesStat
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string Device { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime LoggedTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
