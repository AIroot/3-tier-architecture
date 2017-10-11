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
    public class Branch
    {
        public Branch()
        {
            Latitude = 1.283973M;
            Longitude = 103.860905M;
            IsActive = true;
            IsDelete = false;
            RegDate = DateTime.UtcNow;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string RegNo { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string AddressLine1 { get; set; }

        [DataMember]
        public string AddressLine2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Zip { get; set; }

        [DataMember]
        public int CountryId { get; set; }

        [DataMember]
        public String Street { get; set; }

        [DataMember]
        public string WebSite { get; set; }

        [DataMember]
        public String ProfileUrl { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string LogoUrl { get; set; }

        [DataMember]
        public string ProfileVideoUrl { get; set; }

        [DataMember]
        public decimal Latitude { get; set; }

        [DataMember]
        public decimal Longitude { get; set; }

        [DataMember]
        public decimal Rating { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDelete { get; set; }

        [DataMember]
        public int BranchCount { get; set; }

        [DataMember]
        public TimeSpan OpenTime { get; set; }

        [DataMember]
        public TimeSpan CloseTime { get; set; }

        [DataMember]
        public int? ManagerId { get; set; }

        [DataMember]
        public int SortOrder { get; set; }

        [DataMember]
        public int? CompanyGroupId { get; set; }

        [DataMember]
        public string ConceptDescription { get; set; }

        [DataMember]
        public string Vision { get; set; }

        [DataMember]
        public string Mission { get; set; }

        [DataMember]
        public string Motto { get; set; }

        [DataMember]
        public String AvailableTimePeriod { get; set; }

        [DataMember]
        public decimal Popularity { get; set; }

        [DataMember]
        public string AdminConsoleUrl { get; set; }

        [DataMember]
        public String DefaultImageUrl { get; set; }

        [DataMember]
        public DateTime RegDate { get; set; }

        [DataMember]
        public String CountryName { get; set; }

        [DataMember]
        public String CustomerUserName { get; set; }

        [DataMember]
        public String CustomerPassword { get; set; }

        [DataMember]
        public String ImageUrl { get; set; }

        [DataMember]
        public bool IsServiceActive { get; set; }

        
    }
}
