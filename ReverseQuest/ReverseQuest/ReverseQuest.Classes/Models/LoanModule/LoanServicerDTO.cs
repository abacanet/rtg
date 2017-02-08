using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanModule
{
    public class LoanServicerDTO
    {
        public long LoanServicerSkey { get; set; }
        public string ServicerName { get; set; }
        public int ClientSkey { get; set; }
        public string ContactName { get; set; }
        public string AlternateName { get; set; }
        public string LegalName { get; set; }
        public string LegalNamePart1 { get; set; }
        public string LegalNamePart2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string MainPhoneNumber { get; set; }
        public decimal? AltPhoneNumber { get; set; }
        public decimal? HearingImpairedNumber { get; set; }
        public decimal? FaxNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public string CheckPayableTo { get; set; }
        public string CorrespondenceDept { get; set; }
        public string CorrespondenceContact { get; set; }
        public string FundsReceivedByTime { get; set; }
        public int? LetterLogoHeight { get; set; }
        public int? LetterLogoWidth { get; set; }
        public int? ReportLogoHeight { get; set; }
        public int? ReportLogoWidth { get; set; }
        public byte[] LetterLogoImage { get; set; }
        public byte[] ReportLogoImage { get; set; }
        public byte[] SignatureImage { get; set; }
        public string LetterLogoFiletype { get; set; }
        public string ReportLogoFiletype { get; set; }
        public string SignatureFiletype { get; set; }
        public bool? IsPriorServicerFlag { get; set; }
        public string TaxIdNumber { get; set; }
        public string AbaNumber { get; set; }
        public string AccountNumber { get; set; }
        public string FhaMortgageeNumber { get; set; }
        public string FdicServicerSkey { get; set; }
        public string FdicServicerName { get; set; }
        public string HmbsIssuerId { get; set; }
        public int StatusSkey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
