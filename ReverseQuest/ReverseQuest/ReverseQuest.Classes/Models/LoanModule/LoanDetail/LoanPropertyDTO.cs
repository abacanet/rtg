using System;
using System.Collections.Generic;


namespace ReverseQuest.API.DataTransformationObjects.Loan
{
    public class LoanPropertyDTO : BaseLoanDTO
    {
        public int LoanSkey { get; set; }
        public string PropertyTypeDescription { get; set; }
        public string PropertyAddress1 { get; set; }
        public string PropertyAddress2 { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyStateCode { get; set; }
        public string PropertyZipCode { get; set; }
        public string CountyClerkName { get; set; }
        public int? NumberOfUnits { get; set; }
        public string FloodZoneDescription { get; set; }
        public string FloodZoneShortDescription { get; set; }
        public bool? RequiresFloodInsuranceFlag { get; set; }
        public string FloodCertificateNumber { get; set; }
        public string FloodInsuranceCompanyName { get; set; }
        public bool? LifeOfLoanPolicyFlag { get; set; }
        public bool? OwnerOccupiedFlag { get; set; }
        public DateTime? OccupancyDate { get; set; }
        public DateTime? VacancyDate { get; set; }
        public string LegalDescription { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public int? CountyClerkSkey { get; set; }
        public int FloodZoneSkey { get; set; }
        public int? FloodInsuranceCompanySkey { get; set; }
        public int PropertyTypeSkey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

       
    }
}