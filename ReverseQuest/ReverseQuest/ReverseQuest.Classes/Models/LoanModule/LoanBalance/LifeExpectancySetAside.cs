namespace ReverseQuest.Classes.Models.LoanModule.LoanBalance
{
    public class LifeExpectancySetAside
    {
        public int? Type { get; set; }
        public string TypeDescription { get; set; }
        public decimal? SemiannualAmount { get; set; }
        public int? PaymentStatusSkey { get; set; }
        public string PaymentStatusDescription { get; set; }
        public decimal? FirstYearTaxInsuranceAmount { get; set; }
        public decimal? Balance { get; set; }
    }
}
