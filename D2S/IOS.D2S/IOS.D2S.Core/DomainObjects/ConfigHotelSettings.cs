using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class ConfigHotelSettings
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public bool AllowNextDayCheckIn { get; set; }
        public string OfficialCheckInTime { get; set; }
        public string OfficialCheckOutTime { get; set; }
        public string CheckInStartTime { get; set; }
        public string CheckInEndTime { get; set; }
        public string WifiPassword { get; set; }
        public string HotelManagerName { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string PaymentReceiptsMCPath { get; set; }
        public string GuestArrivalFormPath { get; set; }
        public string GuestInvoicesPath { get; set; }
        public string DocumentScannedImagePath { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegDate { get; set; }
    }
}
