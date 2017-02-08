using System;

namespace ReverseQuest.API.DataTransformationObjects.Loan
{
    public class LoanContactDetailsDTO : BaseLoanDTO
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
    }
}