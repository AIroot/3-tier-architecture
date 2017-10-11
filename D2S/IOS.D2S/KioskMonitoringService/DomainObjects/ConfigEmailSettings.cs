using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.DomainObjects
{
    public class ConfigEmailSettings
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
        public string FromEmail { get; set; }
        public string BCCEmailsInvoices { get; set; }
        public string ToNotificationEmail { get; set; }
        public string CCEmailsNotifications { get; set; }
        public string FailScannedToEmails { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegDate { get; set; }
    }
}
