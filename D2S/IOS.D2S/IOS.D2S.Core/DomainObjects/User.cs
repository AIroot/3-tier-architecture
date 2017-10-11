using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    public class User
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string ImageUrl { get; set; }
        public int SortOrder { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Remark { get; set; }
        public bool IsSystemUser { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }
        public ICollection<Module> Modules { get; set; }



    }
}
