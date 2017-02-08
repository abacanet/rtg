namespace ReverseQuest.Classes.Models.LoanModule.LoanBalance
{
    public class PrincipalLimitCalculation
    {
        public decimal OriginalPrincipalLimit { get; set; }
        public decimal CurrentPrincipalLimit { get; set; }
        public decimal PrincipalBalance { get; set; }
        public decimal InterestBalance { get; set; }
        public decimal MipPmiBalance { get; set; }
        public decimal ServiceFeeBalance { get; set; }

        public decimal LoanBalance { get; set; }
        public decimal ServiceFeeSetAside { get; set; }
        public decimal RepairSetAside { get; set; }
        public decimal FirstYearSetAside { get; set; }
        public decimal OtherSetAside { get; set; }
        public decimal CreditLineSetAside { get; set; }
        public decimal LifeExpectancySetAside { get; set; }
        public decimal NetPrincipalLimit { get; set; }
    }
}
