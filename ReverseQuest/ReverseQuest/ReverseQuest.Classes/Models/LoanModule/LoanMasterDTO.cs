using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanModule
{
    public class LoanMasterDTO
    {
        public long LoanSkey { get; set; }
        public int ParentLoanSkey { get; set; }
        public int LoanServicerSkey { get; set; }
        public int InvestorSkey { get; set; }
        public int LoanPoolSkey { get; set; }
        public int? LoanOriginatorSkey { get; set; }
        public string InvestorLoanNumber { get; set; }
        public string OriginalLoanNumber { get; set; }
        public string FhaCaseNumber { get; set; }
        public string MersMinNumber { get; set; }
        public string GinnieMaeNumber { get; set; }
        public int? LastParticipationId { get; set; }
        public string LoanStatus { get; set; }
        public string LoanSubStatusCode { get; set; }
        public int ProductTypeSkey { get; set; }
        public string BoardingType { get; set; }
        public string AdpCode { get; set; }
        public DateTime? FhaCaseNumberAssignedDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? FundedDate { get; set; }
        public DateTime? MortgageInsuranceCertifiedDate { get; set; }
        public string CreditType { get; set; }
        public decimal? MaximumClaimAmount { get; set; }
        public int PaymentPlanType { get; set; }
        public int PaymentStatusSkey { get; set; }
        public int? PaymentsRemain { get; set; }
        public decimal? MonthlyPrincipalAmount { get; set; }
        public decimal? MonthlyPrincipalAdjustmentAmount { get; set; }
        public decimal? MonthlyServiceFeeAmount { get; set; }
        public decimal? MonthlyTaxEscrowAmount { get; set; }
        public DateTime? FirstPaymentDate { get; set; }
        public decimal? SchPymtFundsReqAmount { get; set; }
        public DateTime? SchPymtFundsReqDate { get; set; }
        public bool? PrintStatementsFlag { get; set; }
        public bool? RsaIncludesAdministrationFeeFlag { get; set; }
        public decimal? OriginationFeeAmount { get; set; }
        public decimal? ClosingFeeAmount { get; set; }
        public decimal? LienPayoffAmount { get; set; }
        public decimal? TotalMandatoryObligationAmount { get; set; }
        public decimal? IdlAmount { get; set; }
        public DateTime? IdlExpirationDate { get; set; }
        public int LesaType { get; set; }
        public decimal? LesaFirstYearTaxInsuranceAmount { get; set; }
        public DateTime? LesaNextSchpayDate { get; set; }
        public int LesaPaymentStatusSkey { get; set; }
        public decimal? LesaSemiannualAmount { get; set; }
        public decimal? LesaSchedulePayFundsRequestAmount { get; set; }
        public DateTime? LesaSchedulePayFundsRequestDate { get; set; }
        public string LoanManager { get; set; }
        public string TaxMonitoringContractType { get; set; }
        public string TaxMonitoringContractNumber { get; set; }
        public DateTime? TransferEffectiveDate { get; set; }
        public DateTime? HudSentToDate { get; set; }
        public DateTime? PayoffDate { get; set; }
        public bool? ProhibitAllCorrespondenceFlag { get; set; }
        public string CustomMessage { get; set; }
        public bool? CustomMessageClearFlag { get; set; }
        public int? PriorServicerSkey { get; set; }
        public string PriorServicerLoanNumber { get; set; }
        public string PriorServicerSubStatus { get; set; }
        public int LoanChannelSkey { get; set; }
        public bool? NoGrowth { get; set; }
        public decimal? GrowthAmount { get; set; }
        public int? ScheduledPaymentDay { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
