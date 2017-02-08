using System;
using System.Collections.Generic;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanContactDetailsDTO : BaseDTO
    {
        public int ContactSkey { get; set; }
        public int? LoanSkey { get; set; }
        public string ContactTypeDescription { get; set; }
        public string OtherContactTypeDescription { get; set; }
        public string FormatedName { get; set; }
        public string FormatedZipCode { get; set; }
        public string FormatedCityStateZip { get; set; }
        public string  SSN { get; set; }
        public string FormattedSsn { get; set; }
        public string GenderDescription { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string HomePhoneNo { get; set; }
        public string WorkPhoneNo { get; set; }
        public string CellPhoneNo { get; set; }
        public string FaxPhoneNo { get; set; }
        public string Email { get; set; }
        public string FormatedMailName { get; set; }
        public string FormatedMailZipCode { get; set; }
        public string FormatedMailCityStateZip { get; set; }
        public string MaritalStatusDescription { get; set; }
        public string LanguagePreferenceDescription { get; set; }
        public string CompanyName { get; set; }
        public string MailCompanyName { get; set; }
        public string ResidencyStatusDescription { get; set; }
        public bool? EmergencyContactFlag { get; set; }
        public bool? AuthorizedContactFlag { get; set; }
        public bool? EnbsIndicator { get; set; }
        public bool? LegalOwnerFlag { get; set; }
        public bool? RightToOccupyFlag { get; set; }
        public bool? DivorcedFlag { get; set; }
        public string MortgageeOptionalElection { get; set; }
        public bool? EmailPreferredFlag { get; set; }
        public bool UseCompanyFieldFlag { get; set; }
        public string Borrower { get; set; }
        public int ContactTypeSkey { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string MailingFirstName { get; set; }
        public string MailingMiddleName { get; set; }
        public string MailingLastName { get; set; }
        public string MailAddress1 { get; set; }
        public string MailAddress2 { get; set; }
        public string MailCity { get; set; }
        public string MailStateCode { get; set; }
        public string  MailZipCode { get; set; }
        public int? MaritalStatusSkey { get; set; }
        public int LanguagePreferenceSkey { get; set; }
        public int ResidencyStatusSkey { get; set; }
        public int? ParentContactSkey { get; set; }
        public Guid? UserSkey { get; set; }
        public int SignatureImageTypeSkey { get; set; }
        public int? StatusSkey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] ContactSignatureImage { get; set; }

        public LoanContactDetailsDTO MapFromEntity(usp_GetDetailsLoanContact_Result entity)
        {
            return new LoanContactDetailsDTO
            {
                LoanSkey = entity.loan_skey,
                ModifiedDate = entity.modified_date,
                ModifiedBy = entity.modified_by,
                CreatedDate = entity.created_date,
                CreatedBy = entity.created_by,
                ContactSkey = entity.contact_skey,
                Address1 = entity.address1,
                Address2 = entity.address2,
                AuthorizedContactFlag = entity.authorized_contact_flag,
                BirthDate = entity.birth_date,
                Borrower = entity.borrower,
                CellPhoneNo = entity.cell_phone_no,
                City = entity.city,
                CompanyName = entity.company_name,
                ContactSignatureImage = entity.contact_signature_image,
                ContactTypeDescription = entity.contact_type_description,
                ContactTypeSkey = entity.contact_type_skey,
                DeathDate = entity.death_date,
                DivorcedFlag = entity.divorced_flag,
                Email = entity.email,
                EmailPreferredFlag = entity.email_preferred_flag,
                EmergencyContactFlag = entity.emergency_contact_flag,
                EnbsIndicator = entity.enbs_indicator,
                FaxPhoneNo = entity.fax_phone_no,
                FirstName = entity.first_name,
                FormatedCityStateZip = entity.formated_city_state_zip,
                FormatedMailCityStateZip = entity.formated_city_state_zip,
                FormatedMailName = entity.formated_mail_name,
                FormatedName = entity.formated_mail_name,
                FormatedZipCode = entity.formated_zip_code,
                FormatedMailZipCode = entity.formated_mail_zip_code,
                FormattedSsn = entity.formatted_ssn,
                Gender = entity.gender,
                GenderDescription = entity.gender_description,
                HomePhoneNo = entity.home_phone_no,
                LanguagePreferenceDescription = entity.language_preference_description,
                LanguagePreferenceSkey = entity.language_preference_skey,
                LastName = entity.last_name,
                LegalOwnerFlag = entity.legal_owner_flag,
                MailAddress1 = entity.mail_address1,
                MailAddress2 = entity.mail_address2,
                MailCity = entity.mail_city,
                MailCompanyName = entity.mail_company_name,
                MailStateCode = entity.mail_state_code,
                MailingFirstName = entity.mailing_first_name,
                MailingLastName = entity.mailing_last_name,
                MailingMiddleName = entity.mailing_middle_name,
                MaritalStatusDescription = entity.marital_status_description,
                MaritalStatusSkey = entity.marital_status_skey,
                MiddleName = entity.middle_name,
                MortgageeOptionalElection = entity.mortgagee_optional_election,
                OtherContactTypeDescription = entity.other_contact_type_description,
                ParentContactSkey = entity.parent_contact_skey,
                ResidencyStatusDescription = entity.residency_status_description,
                ResidencyStatusSkey = entity.residency_status_skey,
                RightToOccupyFlag = entity.right_to_occupy_flag,
                SignatureImageTypeSkey = entity.signature_image_type_skey,
                StateCode = entity.state_code,
                StatusSkey = entity.status_skey,
                UseCompanyFieldFlag = entity.use_company_field_flag,
                UserSkey = entity.user_skey,
                WorkPhoneNo = entity.work_phone_no,
                ZipCode = entity.zip_code
            };
        }

        public Dictionary<string, object> MapToDictionary()
        {
            return new Dictionary<string, object>
            {
                {"ai_ContactSkey", ContactSkey},
                {"ai_LoanSkey", LoanSkey},
                {"ai_ContactTypeSkey", ContactTypeSkey},
                {"avc_OtherContactTypeDescription", OtherContactTypeDescription},
                {"avc_FirstName", FirstName},
                {"avc_MiddleName", MiddleName},
                {"avc_LastName", LastName},
                {"avc_SSN", SSN},
                {"ac_Gender", Gender},
                {"adtm_BirthDate", BirthDate},
                {"adtm_DeathDate", DeathDate},
                {"avc_Address1", Address1},
                {"avc_Address2", Address2},
                {"avc_City", City},
                {"avc_StateCode", StateCode},
                {"avc_ZipCode", ZipCode},
                {"an_HomePhoneNumber", HomePhoneNo},
                {"an_WorkPhoneNumber", WorkPhoneNo},
                {"an_CellPhoneNumber", CellPhoneNo},
                {"an_FaxNumber", FaxPhoneNo},
                {"avc_Email", Email},
                {"avc_MailFirstName", MailingFirstName},
                {"avc_MailMiddleName", MailingMiddleName},
                {"avc_MailLastName", MailingLastName},
                {"avc_MailAddress1", MailAddress1},
                {"avc_MailAddress2", MailAddress2},
                {"avc_MailCity", MailCity},
                {"avc_MailStateCode", MailStateCode},
                {"avc_MailZipCode", MailZipCode},
                {"ai_MaritalStatusSkey", MaritalStatusSkey},
                {"ai_LanguagePreferenceSkey", LanguagePreferenceSkey},
                {"avc_CompanyName", CompanyName},
                {"avc_MailCompanyName", MailCompanyName},
                {"ai_ResidencyStatusSkey", ResidencyStatusSkey},
                {"ab_EmergencyContactFlag", EmergencyContactFlag},
                {"ab_AuthorizedContactFlag", AuthorizedContactFlag},
                {"ab_ENBSIndicator", EnbsIndicator},
                {"ai_ParentContactSkey", ParentContactSkey},
                {"ab_LegalOwnerFlag", LegalOwnerFlag},
                {"ab_RightToOccupyFlag", RightToOccupyFlag},
                {"ab_DivorcedFlag", DivorcedFlag},
                {"ac_MortgageeOptionalElection", MortgageeOptionalElection},
                {"ab_EmailPreferredFlag", EmailPreferredFlag},
                {"ai_SignatureImageTypeSkey", SignatureImageTypeSkey},
                {"ai_StatusSkey", StatusSkey}
            };
        }
    }
}