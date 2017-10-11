using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class ScheduledCommand
    {
        public int Id { get; set; }
        public int CommandProfileId { get; set; }
        public int CommandStatusId { get; set; }
        public int MachineDetailId { get; set; }
        public int CommandFrequencyId { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public DateTime ExecutedDate { get; set; }
        public string CommandStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsProfileOperation { get; set; }
        public bool IsExecuted { get; set; }
        public bool IsDelete { get; set; }
    }
}
