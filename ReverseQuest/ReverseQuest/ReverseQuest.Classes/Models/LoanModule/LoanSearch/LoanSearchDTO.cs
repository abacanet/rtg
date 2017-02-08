using System;

namespace ReverseQuest.Classes.Models.LoanModule.LoanSearch
{
    public class LoanSearchDTO 
    {
        public int LoanSkey { get; set; }
        public string OriginalLoanNumber { get; set; }
        public string FhaCaseNumber { get; set; }
        public string PriorServicerLoanNumber { get; set; }
        public string InvestorLoanNumber { get; set; }
        public string LoanStatus { get; set; }
        public string LoanSubStatus { get; set; }
        public string BorrowerFirstName { get; set; }
        public string BorrowerLastName { get; set; }
        public string CoborrowerFirstName { get; set; }
        public string CoborrowerLastName { get; set; }
        public string BorrowerPhoneNumber { get; set; }
        public string EnbsFirstName { get; set; }
        public string EnbsLastName { get; set; }
        public string PropertyAddress1 { get; set; }
        public string PropertyAddress2 { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyCounty { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZipcode { get; set; }
        public string ServicerName { get; set; }
        public string InvestorName { get; set; }
        public string LoanPoolDescription { get; set; }
        public string ProductTypeDescription { get; set; }
        public string PaymentPlanTypeDescription { get; set; }
        public string ArmTypeDescription { get; set; }
        public string RateIndexTypeDescription { get; set; }
        public string Spoc { get; set; }
        public string BoardedBy { get; set; }
        public DateTime? BoardedDate { get; set; }
        public string BoardingTypeDescription { get; set; }
        public string CreditTypeDescription { get; set; }
        public string MersMinNumber { get; set; }
        public string LoanSubStatusCode { get; set; }
        public int? LoanServicerSkey { get; set; }
        public int? InvestorSkey { get; set; }
        public int? LoanPoolSkey { get; set; }
        public int? ProductTypeSkey { get; set; }
        public int? PaymentPlanType { get; set; }
        public string ArmType { get; set; }
        public int? RateIndexTypeSkey { get; set; }
        public int? SpocSkey { get; set; }
        public string BoardingType { get; set; }
        public string CreditType { get; set; }
        public int? RecordCount { get; set; }
        public string LoanStatusCode { get; set; }
        public string Filler { get; set; }
    }
}