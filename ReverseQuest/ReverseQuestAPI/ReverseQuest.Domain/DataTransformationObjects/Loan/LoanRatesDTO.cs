using System;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanRatesDTO : BaseDTO
    {
        public long LoanSkey { get; set; }
        public string ArmType { get; set; }
        public int RateIndexTypeSkey { get; set; }
        public DateTime? FirstArmChangeDate { get; set; }
        public DateTime? NextArmChangeDate { get; set; }
        public decimal? ExpectedInterestRate { get; set; }
        public decimal? InterestRateAtClosing { get; set; }
        public decimal MipRate { get; set; }
        public decimal? Margin { get; set; }
        public bool? Rounding { get; set; }
        public decimal? InterestRateLifetimeMax { get; set; }
        public decimal? InterestRateMaxFromClosingRate { get; set; }
        public decimal? InterestRateMaxFromCurrentRate { get; set; }
        public decimal? PreviousInterestRate { get; set; }
        public decimal? CurrentInterestRate { get; set; }
        public decimal? NextInterestRate { get; set; }
        public decimal? PreviousRateIndex { get; set; }
        public decimal? CurrentRateIndex { get; set; }
        public decimal? NextRateIndex { get; set; }
        public DateTime? IndexPublishDate { get; set; }
        public decimal? DebentureInterestRate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public LoanRatesDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new LoanRatesDTO
            {
                FirstArmChangeDate = entity.first_arm_change_date,
                NextArmChangeDate = entity.next_arm_change_date,
                ExpectedInterestRate = entity.expected_interest_rate,
                InterestRateAtClosing = entity.interest_rate_at_closing,
                MipRate = entity.mip_rate,
                Margin = entity.margin,
                Rounding = entity.rounding,
                InterestRateLifetimeMax = entity.interest_rate_lifetime_max,
                InterestRateMaxFromCurrentRate = entity.interest_rate_max_from_current_rate,
                InterestRateMaxFromClosingRate = entity.interest_rate_max_from_closing_rate,
                PreviousInterestRate = entity.previous_interest_rate,
                CurrentInterestRate = entity.current_interest_rate,
                NextInterestRate = entity.next_interest_rate,
                PreviousRateIndex = entity.previous_rate_index,
                CurrentRateIndex = entity.current_rate_index,
                NextRateIndex = entity.next_rate_index,
                IndexPublishDate = entity.index_publish_date,
                DebentureInterestRate = entity.debenture_interest_rate,
                ArmType = entity.arm_type,
                RateIndexTypeSkey = entity.rate_index_type_skey,
                ModifiedDate = entity.rates_modified_date,
                ModifiedBy = entity.rates_modified_by
            };
        }
    }
}