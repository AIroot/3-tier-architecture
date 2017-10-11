using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class RolePrivilage
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int FeatureId { get; set; }
        public int OperationId { get; set; }
        public int BranchId { get; set; }
        public bool IsDelete { get; set; }
    }
}
