using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class LogGuestScanData
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string ProfileId { get; set; }
        public string ProfileCode { get; set; }
        public string Salutation { get; set; }
        public string FullName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Occupation { get; set; }
        public string PlaceOfEmployment { get; set; }
        public string LastCountryEmbarkation { get; set; }
        public string LastCountryEmbarkationAddr { get; set; }
        public string NextDestination { get; set; }
        public string BookingReference { get; set; }
        public string DocumentId { get; set; }
        public int ReservationId { get; set; }
        public string Url { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LogDate { get; set; }
    }
}
