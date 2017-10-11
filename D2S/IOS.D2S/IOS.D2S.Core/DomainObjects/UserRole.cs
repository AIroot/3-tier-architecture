using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool CanDeleteOrUpdate { get; set; }
    }
}
