using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanBalanceDTO : BaseDTO
    {
        public long LoanSkey { get; set; }
        public decimal? OriginalPrincipalLimit { get; set; }
        public decimal? CurrentPrincipalLimit { get; set; }
        public decimal? LoanBalance { get; set; }
        public decimal? ServiceFeeSetAsideBalance { get; set; }
        public decimal? FirstYearSetAsideBalance { get; set; }
        public decimal? RepairSetAsideBalance { get; set; }
        public decimal? NetCreditLine { get; set; }
        public decimal? NetPrincipalLimit { get; set; }
        public decimal? OriginalPlanCreditLineSetAside { get; set; }
        public decimal? MonthlyPrincipalAmount { get; set; }
        public decimal? MonthlyTaxEscrowAmount { get; set; }
        public decimal? NetMonthlyPaymentAmount { get; set; }
        public decimal? MaximumClaimAmount { get; set; }
        public decimal? MonthlyServiceFeeAmount { get; set; }
        public bool? PrintStatementsFlag { get; set; }
        public bool? ProhibitAllCorrespondenceFlag { get; set; }
        public decimal? CurrentPlanOriginalCreditLine { get; set; }
        public decimal? PrincipalBalance { get; set; }
        public decimal? InterestBalance { get; set; }
        public decimal? MipBalance { get; set; }
        public decimal? ServiceFeeBalance { get; set; }
        public decimal? CurrentGrossCreditLine { get; set; }
        public decimal? InitialMipPaidByBorrower { get; set; }
        public decimal? InitialMipPaidByLender { get; set; }
        public decimal? CurrentTaxInsuranceWitheldBalance { get; set; }
        public decimal? UnscheduledCreditLineDisbursementAccrualBalance { get; set; }
        public string NplDescription { get; set; }
        public LifeExpectancySetAside LifeExpectancySetAside { get; set; }
        public Idl Idl { get; set; }
        public PaymentDTO Payment { get; set; }
        public PaymentPlanTypeDTO PaymentPlanType { get; set; }

        public LoanBalanceDTO MapFromEntity(usp_GetDetailsLoanBalances_Result entity)
        {
            var loanBalanceDTO = new LoanBalanceDTO().MapFromEntity(entity);
            loanBalanceDTO.LifeExpectancySetAside = new LifeExpectancySetAside().MapFromEntity(entity);
            loanBalanceDTO.Idl = new Idl().MapFromEntity(entity);
            loanBalanceDTO.Payment = new PaymentDTO().MapFromEntity(entity);
            loanBalanceDTO.PaymentPlanType = new PaymentPlanTypeDTO().MapFromEntity(entity);

            return loanBalanceDTO;
        }
    }
}
