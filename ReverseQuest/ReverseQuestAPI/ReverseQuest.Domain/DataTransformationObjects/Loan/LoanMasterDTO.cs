using System;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanMasterDTO : BaseDTO
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
        public string LoanManagerId { get; set; }
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

        //From Functions
        public string BoardingTypeDescription { get; set; }
        public string  CreditTypeDescription { get; set; }
        public decimal? MonthlyPaymentAmount { get; set; }
        public string UserLoanManager { get; set; }
        public decimal? FirstPageFeeAmount { get; set; }

        public LoanMasterDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new LoanMasterDTO
            {
                LoanSkey = entity.loan_skey,
                PaymentPlanType = entity.payment_plan_type,
                PaymentStatusSkey = entity.payment_status_skey,
                MaximumClaimAmount = entity.maximum_claim_amount,
                MonthlyTaxEscrowAmount = entity.monthly_tax_escrow_amount,
                MonthlyPrincipalAmount = entity.monthly_principal_amount,
                ProhibitAllCorrespondenceFlag = entity.prohibit_all_correspondence_flag,
                MonthlyServiceFeeAmount = entity.monthly_service_fee_amount,
                PaymentsRemain = entity.payments_remain,
                CreatedDate = entity.created_date,
                PrintStatementsFlag = entity.print_statements_flag,
                CreatedBy = entity.created_by,
                AdpCode = entity.adp_code,
                BoardingType = entity.boarding_type,
                ClosingDate = entity.closing_date,
                CreditType = entity.credit_type,
                FhaCaseNumber = entity.fha_case_number,
                FhaCaseNumberAssignedDate = entity.fha_case_number_assigned_date,
                FundedDate = entity.funded_date,
                GinnieMaeNumber = entity.ginnie_mae_number,
                HudSentToDate = entity.hud_sent_to_date,
                InvestorLoanNumber = entity.investor_loan_number,
                LoanChannelSkey = entity.loan_channel_skey,
                LoanManager = entity.loan_manager,
                LoanManagerId = entity.loan_manager_id,
                LoanOriginatorSkey = entity.loan_originator_skey,
                LoanStatus = entity.loan_status,
                LoanSubStatusCode = entity.loan_sub_status_code,
                MersMinNumber = entity.mers_min_number,
                ModifiedBy = entity.modified_by,
                ModifiedDate = entity.modified_date,
                MonthlyPrincipalAdjustmentAmount = entity.monthly_principal_adjustment_amount,
                MortgageInsuranceCertifiedDate = entity.mortgage_insurance_certified_date,
                OriginalLoanNumber = entity.original_loan_number,
                PayoffDate = entity.payoff_date,
                PriorServicerLoanNumber = entity.prior_servicer_loan_number,
                PriorServicerSkey = entity.prior_servicer_skey,
                PriorServicerSubStatus = entity.prior_servicer_sub_status,
                ProductTypeSkey = entity.product_type_skey,
                RsaIncludesAdministrationFeeFlag = entity.rsa_includes_administration_fee_flag,
                TaxMonitoringContractNumber = entity.tax_monitoring_contract_number,
                TaxMonitoringContractType = entity.tax_monitoring_contract_type,
                TransferEffectiveDate = entity.transfer_effective_date,
                BoardingTypeDescription = entity.boarding_type_description,
                CreditTypeDescription = entity.credit_type_description,
                MonthlyPaymentAmount = entity.net_monthly_payment_amount,
                UserLoanManager = entity.loan_manager,
                FirstPageFeeAmount = entity.first_page_fee_amt
            };
        }
    }
}