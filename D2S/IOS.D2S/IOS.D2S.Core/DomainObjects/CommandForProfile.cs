using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class CommandForProfile
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public int ProfileId { get; set; }
        public int CommandId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public string FrequencyDuration { get; set; }
    }
}
