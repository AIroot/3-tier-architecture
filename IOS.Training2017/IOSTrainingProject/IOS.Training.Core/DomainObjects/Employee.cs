using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.Core.DomainObjects
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string IconUrl { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string MobileNo { get; set; }
    }
}
