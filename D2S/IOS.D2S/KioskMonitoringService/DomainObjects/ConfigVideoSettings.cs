using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.DomainObjects
{
    public class ConfigVideoSettings
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string ScanQRVideoPath { get; set; }
        public string ScanPassportVideoPath { get; set; }
        public string CollectPassportVideoPath { get; set; }
        public string InsertCreditCardVideoPath { get; set; }
        public string CollectCreditCardVideoPath { get; set; }
        public string EnterPinVideoPath { get; set; }
        public string EncodeKeyCardVideoPath { get; set; }
        public string CollectKeyCardVideoPath { get; set; }
        public string CollectWelcomeNoteVideoPath { get; set; }
        public string InsertKeyCardVideoPath { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegDate { get; set; }
    }
}
