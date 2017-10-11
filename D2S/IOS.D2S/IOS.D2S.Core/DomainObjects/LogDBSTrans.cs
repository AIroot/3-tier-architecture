using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class LogDBSTrans
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string TID { get; set; }
        public string MID { get; set; }
        public string Batch { get; set; }
        public string InvoiceId { get; set; }
        public string PAN { get; set; }
        public string APCode { get; set; }
        public DateTime TransDate { get; set; }
        public string Card { get; set; }
        public decimal Amount { get; set; }
        public bool IsDelete { get; set; }
    }
}
