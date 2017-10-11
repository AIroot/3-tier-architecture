using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class MachineAppDetail
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentStatus { get; set; }
        public DateTime LastResponseTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
