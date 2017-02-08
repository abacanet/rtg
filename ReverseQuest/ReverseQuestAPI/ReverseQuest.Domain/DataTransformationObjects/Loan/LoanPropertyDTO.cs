using System;
using System.Collections.Generic;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanPropertyDTO : BaseDTO
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

        public LoanPropertyDTO FromEntityModel(usp_GetDetailsLoanProperty_Result entity)
        {
            return new LoanPropertyDTO
            {
                LoanSkey = entity.loan_skey,
                CreatedDate = entity.created_date,
                CreatedBy = entity.created_by,
                ModifiedBy = entity.modified_by,
                ModifiedDate = entity.modified_date,
                ZipCode = entity.zip_code,
                PropertyCity = entity.property_city,
                Address2 = entity.address2,
                Address1 = entity.address1,
                City = entity.city,
                PropertyAddress1 = entity.property_address1,
                PropertyAddress2 = entity.property_address2,
                StateCode = entity.state_code,
                CountyClerkName = entity.county_clerk_name,
                CountyClerkSkey = entity.county_clerk_skey,
                FloodCertificateNumber = entity.flood_certificate_number,
                FloodInsuranceCompanyName = entity.flood_insurance_company_name,
                FloodInsuranceCompanySkey = entity.flood_insurance_company_skey,
                FloodZoneDescription = entity.flood_zone_description,
                FloodZoneShortDescription = entity.flood_zone_short_description,
                FloodZoneSkey = entity.flood_zone_skey,
                LegalDescription = entity.legal_description,
                LifeOfLoanPolicyFlag = entity.life_of_loan_policy_flag,
                NumberOfUnits = entity.number_of_units,
                OccupancyDate = entity.occupancy_date,
                OwnerOccupiedFlag = entity.owner_occupied_flag,
                PropertyStateCode = entity.property_state_code,
                PropertyTypeDescription = entity.property_type_description,
                PropertyTypeSkey = entity.property_type_skey,
                PropertyZipCode = entity.property_zip_code,
                RequiresFloodInsuranceFlag = entity.requires_flood_insurance_flag,
                VacancyDate = entity.vacancy_date
            };
        }

        public Dictionary<string, object> ToParametersDictionary()
        {
            return new Dictionary<string, object>
            {
                {"ai_LoanSkey", LoanSkey},
                {"avc_Address1", Address1},
                {"avc_Address2", Address2},
                {"avc_City", City},
                {"avc_StateCode", StateCode},
                {"avc_ZipCode", ZipCode},
                {"avc_LegalDescription", LegalDescription},
                {"ab_OwnerOccupiedFlag", OwnerOccupiedFlag},
                {"adtm_OccupancyDate", OccupancyDate},
                {"ai_CountyClerkSkey", CountyClerkSkey},
                {"ai_PropertyTypeSkey", PropertyTypeSkey},
                {"ai_NumberOfUnits", NumberOfUnits},
                {"ai_FloodZoneSkey", FloodZoneSkey},
                {"ab_RequiresFloodInsuranceFlag", RequiresFloodInsuranceFlag},
                {"avc_FloodCertificateNumber", FloodCertificateNumber},
                {"ai_FloodInsuranceCompanySkey", FloodInsuranceCompanySkey},
                {"ab_LifeOfLoanPolicyFlag", LifeOfLoanPolicyFlag},
                {"adtm_VacancyDate", VacancyDate}
            };
        }
    }
}