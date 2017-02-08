using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanModule.LoanDetail
{
    public class LoanRate
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
    }
}
