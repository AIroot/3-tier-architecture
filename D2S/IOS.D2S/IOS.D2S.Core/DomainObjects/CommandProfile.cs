using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class CommandProfile
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        public int AddedUser { get; set; }
        public DateTime ActiveStartDate { get; set; }
        public DateTime ActiveEndDate { get; set; }
        public int ModifiedUser { get; set; }
        public DateTime RegDate { get; set; }
        public bool IsDelete { get; set; }     
    }
}
