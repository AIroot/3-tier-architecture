using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.DomainObjects
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Operation
    {
        public Operation()
        {
            IsActive = true;
            IsDelete = false;
            IsSelected = false;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDelete { get; set; }

        [DataMember]
        public int SortOrder { get; set; }

        [DataMember]
        public int BranchId { get; set; }

        // Not Mapped Properties
        [DataMember]
        public bool IsSelected { get; set; }
    }
}
