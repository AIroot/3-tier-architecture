using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class LogCheckInDropOff
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int ReservationId { get; set; }
        public string PageLeft { get; set; }
        public TimeSpan SpentTime { get; set; }
        public DateTime LogDateTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
