using System;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class Idl
    {
        public long LoanSkey { get; set; }
        public decimal? CreditLineDisbursementAmount { get; set; }
        public decimal? InterestMipServiceFeeRepayAmount { get; set; }
        public decimal? LoanBalance { get; set; }
        public decimal? CurrentNet { get; set; }
        public decimal? CurrentGrossCreditLine { get; set; }
        public decimal? CurrentNetCreditLine { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ExpirationDate { get;  set; }
        public decimal? NetGrowthAmount { get; set; }

        public Idl MapFromEntity(usp_GetDetailsLoanBalances_Result entity)
        {
            return new Idl
            {
                Amount = entity.idl_amount,
                CreditLineDisbursementAmount = entity.IDL_credit_line_disbursement_amount,
                CurrentGrossCreditLine = entity.current_IDL_gross_credit_line,
                CurrentNet = entity.current_net_IDL,
                CurrentNetCreditLine = entity.current_IDL_net_credit_line,
                ExpirationDate = entity.idl_expiration_date,
                InterestMipServiceFeeRepayAmount = entity.IDL_interest_MIP_service_fee_repay_amount,
                LoanBalance = entity.IDL_loan_balance,
                NetGrowthAmount = entity.net_growth_amount
            };
        }
    }
}