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
    public class Feature
    {
        public Feature()
        {
            IsActive = true;
            IsDelete = false;
            IsSelected = false;
            Operations = new List<Operation>();
            Operation = new Operation();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string BgColor { get; set; }

        [DataMember]
        public string FgColor { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDelete { get; set; }

        [DataMember]
        public string ToolTip { get; set; }

        [DataMember]
        public int SortOrder { get; set; }

        [DataMember]
        public string NavigationUrl { get; set; }

        [DataMember]
        public int BranchId { get; set; }

        [DataMember]
        public List<Operation> Operations { get; set; }

        [DataMember]
        public Operation Operation { get; set; }

        // Not Mapped Properties
        [DataMember]
        public bool IsSelected { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }


    }
}
