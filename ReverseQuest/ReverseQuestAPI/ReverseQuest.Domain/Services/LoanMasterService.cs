using System;
using System.Threading.Tasks;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Async;

namespace ReverseQuest.Domain.Services
{
    public class LoanMasterService : IServiceGetEntityBySkeyAsync<LoanMasterDTO, app_loan_master>,
        IServiceUpdateEntityBySkeyAsync<LoanMasterDTO, app_loan_master>
    {
        public async Task<LoanMasterDTO> GetEntityBySkeyAsync(IRepositoryAsync<app_loan_master> repository, int skey)
        {
            var result = await repository.GetAsync(skey);
            return MapToDTO(result);
        }

        public async Task<int> UpdateEntityBySkeyAsync(IRepositoryAsync<app_loan_master> repository, LoanMasterDTO entity, int skey)
        {
            //get LoanMaster from the DB to avoid erasing unused properties
            var loanMaster = await repository.GetAsync(skey);

            if (loanMaster == null)
                throw new Exception("Entity not found on the database");

            MapToEntity(entity, ref loanMaster);

            return await repository.UpdateAsync(loanMaster, skey);
        }

        private static void MapToEntity(LoanMasterDTO loanMasterDTO, ref app_loan_master appLoanMaster)
        {
            //only a smaller subset (below) of LoanMaster can be updated due to business constraints
            appLoanMaster.loan_originator_skey = loanMasterDTO.LoanOriginatorSkey;
            appLoanMaster.investor_loan_number = loanMasterDTO.InvestorLoanNumber;
            appLoanMaster.original_loan_number = loanMasterDTO.OriginalLoanNumber;
            appLoanMaster.fha_case_number = loanMasterDTO.FhaCaseNumber;
            appLoanMaster.mers_min_number = loanMasterDTO.MersMinNumber;
            appLoanMaster.adp_code = loanMasterDTO.AdpCode;
            appLoanMaster.fha_case_number_assigned_date = loanMasterDTO.FhaCaseNumberAssignedDate;
            appLoanMaster.closing_date = loanMasterDTO.ClosingDate;
            appLoanMaster.funded_date = loanMasterDTO.FundedDate;
            appLoanMaster.mortgage_insurance_certified_date = loanMasterDTO.MortgageInsuranceCertifiedDate;
            appLoanMaster.credit_type = loanMasterDTO.CreditType;
            appLoanMaster.maximum_claim_amount = loanMasterDTO.MaximumClaimAmount;
            appLoanMaster.payment_plan_type = loanMasterDTO.PaymentPlanType;
            appLoanMaster.payment_status_skey = loanMasterDTO.PaymentStatusSkey;
            appLoanMaster.payments_remain = loanMasterDTO.PaymentsRemain;
            appLoanMaster.monthly_principal_amount = loanMasterDTO.MonthlyPrincipalAmount;
            appLoanMaster.monthly_service_fee_amount = loanMasterDTO.MonthlyServiceFeeAmount;
            appLoanMaster.monthly_tax_escrow_amount = loanMasterDTO.MonthlyTaxEscrowAmount;
            appLoanMaster.print_statements_flag = loanMasterDTO.PrintStatementsFlag;
            appLoanMaster.rsa_includes_administration_fee_flag = loanMasterDTO.RsaIncludesAdministrationFeeFlag;
            appLoanMaster.origination_fee_amount = loanMasterDTO.OriginationFeeAmount;
            appLoanMaster.closing_fee_amount = loanMasterDTO.ClosingFeeAmount;
            appLoanMaster.lien_payoff_amount = loanMasterDTO.LienPayoffAmount;
            appLoanMaster.total_mandatory_obligation_amount = loanMasterDTO.TotalMandatoryObligationAmount;
            appLoanMaster.LESA_payment_status_skey = loanMasterDTO.LesaPaymentStatusSkey;
            appLoanMaster.loan_manager = loanMasterDTO.LoanManager;
            appLoanMaster.prohibit_all_correspondence_flag = loanMasterDTO.ProhibitAllCorrespondenceFlag;
            appLoanMaster.custom_message = loanMasterDTO.CustomMessage;
            appLoanMaster.custom_message_clear_flag = loanMasterDTO.CustomMessageClearFlag;
            appLoanMaster.prior_servicer_skey = loanMasterDTO.PriorServicerSkey;
            appLoanMaster.prior_servicer_loan_number = loanMasterDTO.PriorServicerLoanNumber;
            appLoanMaster.prior_servicer_sub_status = loanMasterDTO.PriorServicerSubStatus;
            appLoanMaster.loan_channel_skey = loanMasterDTO.LoanChannelSkey;
            appLoanMaster.modified_by = loanMasterDTO.ModifiedBy;
        }

        private static LoanMasterDTO MapToDTO(app_loan_master appLoanMaster)
        {
            if (appLoanMaster == null) return null;

            return new LoanMasterDTO()
            {
                LoanSkey = appLoanMaster.loan_skey,
                PaymentPlanType = appLoanMaster.payment_plan_type,
                PaymentStatusSkey = appLoanMaster.payment_status_skey,
                MaximumClaimAmount = appLoanMaster.maximum_claim_amount,
                MonthlyTaxEscrowAmount = appLoanMaster.monthly_tax_escrow_amount,
                MonthlyPrincipalAmount = appLoanMaster.monthly_principal_amount,
                ProhibitAllCorrespondenceFlag = appLoanMaster.prohibit_all_correspondence_flag,
                MonthlyServiceFeeAmount = appLoanMaster.monthly_service_fee_amount,
                PaymentsRemain = appLoanMaster.payments_remain,
                CreatedDate = appLoanMaster.created_date,
                PrintStatementsFlag = appLoanMaster.print_statements_flag,
                CreatedBy = appLoanMaster.created_by,
                AdpCode = appLoanMaster.adp_code,
                BoardingType = appLoanMaster.boarding_type,
                ClosingDate = appLoanMaster.closing_date,
                ClosingFeeAmount = appLoanMaster.closing_fee_amount,
                CreditType = appLoanMaster.credit_type,
                CustomMessage = appLoanMaster.custom_message,
                CustomMessageClearFlag = appLoanMaster.custom_message_clear_flag,
                FhaCaseNumber = appLoanMaster.fha_case_number,
                FhaCaseNumberAssignedDate = appLoanMaster.fha_case_number_assigned_date,
                FirstPaymentDate = appLoanMaster.first_payment_date,
                FundedDate = appLoanMaster.funded_date,
                GinnieMaeNumber = appLoanMaster.ginnie_mae_number,
                GrowthAmount = appLoanMaster.growth_amount,
                HudSentToDate = appLoanMaster.hud_sent_to_date,
                IdlAmount = appLoanMaster.idl_amount,
                IdlExpirationDate = appLoanMaster.idl_expiration_date,
                InvestorLoanNumber = appLoanMaster.investor_loan_number,
                InvestorSkey = appLoanMaster.investor_skey,
                LastParticipationId = appLoanMaster.last_participation_id,
                LesaFirstYearTaxInsuranceAmount = appLoanMaster.LESA_first_year_tax_insurance_amount,
                LesaNextSchpayDate = appLoanMaster.LESA_next_schpay_date,
                LesaPaymentStatusSkey = appLoanMaster.LESA_payment_status_skey,
                LesaSchedulePayFundsRequestAmount = appLoanMaster.LESA_schedule_pay_funds_request_amount,
                LesaSchedulePayFundsRequestDate = appLoanMaster.LESA_schedule_pay_funds_request_date,
                LesaSemiannualAmount = appLoanMaster.LESA_semiannual_amount,
                LesaType = appLoanMaster.LESA_type,
                LienPayoffAmount = appLoanMaster.lien_payoff_amount,
                LoanChannelSkey = appLoanMaster.loan_channel_skey,
                LoanManager = appLoanMaster.loan_manager,
                LoanOriginatorSkey = appLoanMaster.loan_originator_skey,
                LoanPoolSkey = appLoanMaster.loan_pool_skey,
                LoanServicerSkey = appLoanMaster.loan_servicer_skey,
                LoanStatus = appLoanMaster.loan_status,
                LoanSubStatusCode = appLoanMaster.loan_sub_status_code,
                MersMinNumber = appLoanMaster.mers_min_number,
                ModifiedBy = appLoanMaster.modified_by,
                ModifiedDate = appLoanMaster.modified_date,
                MonthlyPrincipalAdjustmentAmount = appLoanMaster.monthly_principal_adjustment_amount,
                MortgageInsuranceCertifiedDate = appLoanMaster.mortgage_insurance_certified_date,
                NoGrowth = appLoanMaster.no_growth,
                OriginalLoanNumber = appLoanMaster.original_loan_number,
                OriginationFeeAmount = appLoanMaster.origination_fee_amount,
                ParentLoanSkey = appLoanMaster.parent_loan_skey,
                PayoffDate = appLoanMaster.payoff_date,
                PriorServicerLoanNumber = appLoanMaster.prior_servicer_loan_number,
                PriorServicerSkey = appLoanMaster.prior_servicer_skey,
                PriorServicerSubStatus = appLoanMaster.prior_servicer_sub_status,
                ProductTypeSkey = appLoanMaster.product_type_skey,
                RsaIncludesAdministrationFeeFlag = appLoanMaster.rsa_includes_administration_fee_flag,
                SchPymtFundsReqAmount = appLoanMaster.sch_pymt_funds_req_amount,
                SchPymtFundsReqDate = appLoanMaster.sch_pymt_funds_req_date,
                ScheduledPaymentDay = appLoanMaster.scheduled_payment_day,
                TaxMonitoringContractNumber = appLoanMaster.tax_monitoring_contract_number,
                TaxMonitoringContractType = appLoanMaster.tax_monitoring_contract_type,
                TotalMandatoryObligationAmount = appLoanMaster.total_mandatory_obligation_amount,
                TransferEffectiveDate = appLoanMaster.transfer_effective_date
            };

        }
    }
}
