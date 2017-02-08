using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanModule.LoanSearch
{
    public class LoanSearchParameterDTO
    {
        public int? aiLoanSKey { get; set; }
        public string avcOriginalLoanNumber { get; set; }
        public string avcFhaCaseNumber { get; set; }
        public string avcInvestorLoanNumber { get; set; }
        public string avcPriorServicerLoanNumber { get; set; }
        public string avcLoanStatus { get; set; }
        public string avcLoanSubStatusCodes { get; set; }
        public string avcContactFirstName { get; set; }
        public string avcContactLastName { get; set; }
        public string avcContactPhoneNumber { get; set; }
        public string avcContactTypeSKeys { get; set; }
        public string avcPropertyAddress { get; set; }
        public string avcPropertyCity { get; set; }
        public string avcPropertyStateCodes { get; set; }
        public string avcPropertyZipCode { get; set; }
        public string avcLoanServicerSKeys { get; set; }
        public string avcInvestorSKeys { get; set; }
        public string avcLoanPoolSKeys { get; set; }
        public string avcProductTypeSKeys { get; set; }
        public string avcPaymentPlanTypes { get; set; }
        public string avcArmTypes { get; set; }
        public string avcRateIndexTypeSKeys { get; set; }
        public string avcSpocsKey { get; set; }
        public string adtmBoardedDateFrom { get; set; }
        public DateTime? adtmBoardedDateTo { get; set; }
        public DateTime? avcBoardingType { get; set; }
        public string avcCreditType { get; set; }
        public string avcIncludeAlerts { get; set; }
        public string avcExcludeAlerts { get; set; }
        public string avcIncludeDocs { get; set; }
        public string avcExcludeDocs { get; set; }

    }
}
