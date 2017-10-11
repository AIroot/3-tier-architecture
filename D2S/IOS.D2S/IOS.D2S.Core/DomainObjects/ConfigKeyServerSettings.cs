using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class ConfigKeyServerSettings
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string SaflokServerIP { get; set; }
        public string SaflokServerPort { get; set; }
        public string KeyExpirationTime { get; set; }
        public string EncoderNumber { get; set; }
        public string PMSTerminalNumber { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegDate { get; set; }
    }
}
