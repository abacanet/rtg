
namespace ReverseQuest.Reversequest.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Reversequest.LoanSearchResults")]
    [BasedOnRow(typeof(Entities.LoanSearchResultsRow))]
    public class LoanSearchResultsForm
    {
       
        public String OriginalLoanNumber { get; set; }
        public String FhaCaseNumber { get; set; }
        public String PriorServicerLoanNumber { get; set; }
        public String InvestorLoanNumber { get; set; }
        public String LoanStatus { get; set; }
        public String LoanSubStatus { get; set; }
        public String BorrowerFirstName { get; set; }
        public String BorrowerMiddleName { get; set; }
        public String BorrowerLastName { get; set; }
        public String CoborrowerFirstName { get; set; }
        public String CoborrowerMiddleName { get; set; }
        public String CoborrowerLastName { get; set; }
        public String BorrowerPhoneNumber { get; set; }
        public String EnbsFirstName { get; set; }
        public String EnbsMiddleName { get; set; }
        public String EnbsLastName { get; set; }
        public String PropertyAddress1 { get; set; }
        public String PropertyAddress2 { get; set; }
        public String PropertyCity { get; set; }
        public String PropertyCounty { get; set; }
        public String PropertyState { get; set; }
        public String PropertyZipcode { get; set; }
        public String ServicerName { get; set; }
        public String InvestorName { get; set; }
        public String LoanPoolDescription { get; set; }
        public String ProductTypeDescription { get; set; }
        public String PaymentPlanTypeDescription { get; set; }
        public String ArmTypeDescription { get; set; }
        public String RateIndexTypeDescription { get; set; }
        public String LoanManagerName { get; set; }
        public String BoardedBy { get; set; }
        public DateTime BoardedDate { get; set; }
        public String BoardingTypeDescription { get; set; }
        public String CreditTypeDescription { get; set; }
        public String MersMinNumber { get; set; }
        public String LoanStatusCode { get; set; }
        public String LoanSubStatusCode { get; set; }
        public Int32 LoanServicerSkey { get; set; }
        public Int32 InvestorSkey { get; set; }
        public Int32 LoanPoolSkey { get; set; }
        public Int32 ProductTypeSkey { get; set; }
        public Int32 PaymentPlanType { get; set; }
        public String ArmType { get; set; }
        public Int32 RateIndexTypeSkey { get; set; }
        public String LoanManagerId { get; set; }
        public String BoardingType { get; set; }
        public String CreditType { get; set; }
        public String Filler { get; set; }
    }
}