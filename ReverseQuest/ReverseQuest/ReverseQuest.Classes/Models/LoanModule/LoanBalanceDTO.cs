using ReverseQuest.Classes.Models.LoanModule.LoanBalance;
using ReverseQuest.Classes.Models.ViewModels;
using System;

namespace ReverseQuest.Classes.Models.LoanModule
{
    public class LoanBalanceDTO
    {
        public long LoanSkey { get; set; }
        public decimal OriginalPrincipalLimit { get; set; }
        public decimal CurrentPrincipalLimit { get; set; }
        public decimal LoanBalance { get; set; }
        public decimal ServiceFeeSetAsideBalance { get; set; }
        public decimal FirstYearSetAsideBalance { get; set; }
        public decimal RepairSetAsideBalance { get; set; }
        public decimal NetCreditLine { get; set; }
        public decimal NetPrincipalLimit { get; set; }
        public decimal OriginalPlanCreditLineSetAside { get; set; }
        public decimal MonthlyPrincipalAmount { get; set; }
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
        public decimal CurrentGrossCreditLine { get; set; }
        public decimal InitialMipPaidByBorrower { get; set; }
        public decimal InitialMipPaidByLender { get; set; }
        public decimal CurrentTaxInsuranceWitheldBalance { get; set; }
        public decimal UnscheduledCreditLineDisbursementAccrualBalance { get; set; }
        public string NplDescription { get; set; }
        public LifeExpectancySetAside LifeExpectancySetAside { get; set; }
        public Idl Idl { get; set; }
        public PaymentDTO Payment { get; set; }
        public PaymentPlanTypeDTO PaymentPlanType { get; set; }

        public static LoanBalanceVM convertModelToVM(LoanBalanceDTO model)
        {
            if (model.LifeExpectancySetAside == null)
            {
                model.LifeExpectancySetAside = new LifeExpectancySetAside();
            }

            if (model.Idl == null)
            {
                model.Idl = new Idl();
            }

            if (model.Payment == null)
            {
                model.Payment = new PaymentDTO();
            }

            if (model.PaymentPlanType == null)
            {
                model.PaymentPlanType = new PaymentPlanTypeDTO();
            }

            return new LoanBalanceVM
            {
                CredLisaInfo = new CredLisaInfo
                {
                    CurrentGrossCreditLine = model.CurrentGrossCreditLine,
                    CurrentNetCreditLine = model.NetCreditLine,
                    CurrentPlanOrigCredLine = model.CurrentPlanOriginalCreditLine.GetValueOrDefault(),
                    OriginalCreditLine = model.OriginalPlanCreditLineSetAside,
                    UnschCredLineDisbBal = model.UnscheduledCreditLineDisbursementAccrualBalance
                },
                InitCredLisaInfo = new InitCredLisaInfo
                {
                    IdlCurrentGrossCreditLine = model.Idl.CurrentGrossCreditLine.GetValueOrDefault(),
                    IdlCurrentNetCreditLine = model.Idl.CurrentNetCreditLine.GetValueOrDefault(),
                    IdlUnschClDisbBal = model.Idl.CreditLineDisbursementAmount.GetValueOrDefault()
                },
                InitDisbLimit = new InitDisbLimit
                {
                    FirstYearLesaTaxAndIns = model.LifeExpectancySetAside.FirstYearTaxInsuranceAmount.GetValueOrDefault(),
                    FirstYearSetAside = model.FirstYearSetAsideBalance,
                    Idl = model.Idl.Amount.GetValueOrDefault(),
                    IdlExpirationDate = model.Idl.ExpirationDate.GetValueOrDefault(),
                    InitialCreditLisa = model.Idl.Amount.GetValueOrDefault(),
                    InitialNetPrincipalLimit = model.NetPrincipalLimit,
                    NetGrowth = model.Idl.NetGrowthAmount.GetValueOrDefault(),
                    PrinBalAndInitMip = model.Idl.LoanBalance.GetValueOrDefault(),
                    RepairSetAside = model.RepairSetAsideBalance,
                },
                LifeExpectancySetAside = model.LifeExpectancySetAside,
                OtherBalance = new OtherBalances
                {
                    ImipPaidByBorrower = model.InitialMipPaidByBorrower,
                    ImipPaidByLender = model.InitialMipPaidByLender,
                    TaxInsuranceWithheld = model.CurrentTaxInsuranceWitheldBalance
                },
                PayPlanInfo = new PayPlanInfo
                {
                    MaximumClaim = model.MaximumClaimAmount.GetValueOrDefault(),
                    MonthlyPayment = model.MonthlyPrincipalAmount,
                    MonthlyServiceFee = model.MonthlyServiceFeeAmount.GetValueOrDefault(),
                    MonthlyTaxAndInsWithheld = model.MonthlyTaxEscrowAmount.GetValueOrDefault(),
                    NetMonthlyPayment = model.NetMonthlyPaymentAmount.GetValueOrDefault(),
                    PaymentStatus = model.Payment.PaymentStatusDescription,
                    PayPlanType = model.PaymentPlanType.PaymentPlanDescription,
                    PrintStatements = model.PrintStatementsFlag,
                    ProhibitAllCorrespondence = model.ProhibitAllCorrespondenceFlag,
                    RemainingPayments = (int)model.Payment.PaymentsRemain
                },
                PrincipalLimitCalc = new PrincipalLimitCalculation
                {
                    CreditLineSetAside = model.NetCreditLine,
                    CurrentPrincipalLimit = model.CurrentPrincipalLimit,
                    FirstYearSetAside = model.FirstYearSetAsideBalance,
                    InterestBalance = model.InterestBalance.GetValueOrDefault(),
                    LifeExpectancySetAside = model.LifeExpectancySetAside.Balance.GetValueOrDefault(),
                    LoanBalance = model.LoanBalance,
                    MipPmiBalance = model.MipBalance.GetValueOrDefault(),
                    NetPrincipalLimit = model.NetPrincipalLimit,
                    OriginalPrincipalLimit = model.OriginalPrincipalLimit,
                    PrincipalBalance = model.PrincipalBalance.GetValueOrDefault(),
                    RepairSetAside = model.RepairSetAsideBalance,
                    ServiceFeeBalance = model.ServiceFeeBalance.GetValueOrDefault(),
                    ServiceFeeSetAside = model.ServiceFeeSetAsideBalance
                }
            };
        }
    }
}
