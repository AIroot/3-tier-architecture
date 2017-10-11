using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class LogGuestPaymentReceipt
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public DateTime LogDate { get; set; }
        public string BookingReference { get; set; }
        public int ResevationId { get; set; }
        public string GuestName { get; set; }
        public string Url { get; set; }
        public bool IsDelete { get; set; }
    }
}
