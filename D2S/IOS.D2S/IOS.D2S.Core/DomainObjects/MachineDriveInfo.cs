﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class MachineDriveInfo
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string DriverName { get; set; }
        public string UsedSpace { get; set; }
        public string FreeSpace { get; set; }
        public string TotalSize { get; set; } 
    }
}
