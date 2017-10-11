using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class LogCheckOutStat
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string BookingReference { get; set; }
        public int ReservationId { get; set; }
        public int NumberOfGuest { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public DateTime CheckedOutTime { get; set; }
        public bool IsDelete { get; set; }

    }
}
