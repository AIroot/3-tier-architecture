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
    public class Module
    {
        public Module()
        {
            IsActive = true;
            IsDelete = false;
            IsSelected = false;
            IsSystemUrl = false;
            Features = new List<Feature>();
            
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

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
        public int BranchId { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public List<Feature> Features { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }

        [DataMember]
        public string NavigationUrl { get; set; }

        [DataMember]
        public bool IsSystemUrl { get; set; }

        [DataMember]
        public bool IsNewWindow { get; set; }

        [DataMember]
        public string DefaultFeatureUrl { get; set; }
    }
}
