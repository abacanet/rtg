namespace ReverseQuest.Classes.Models.LoanModule.LoanBalance
{
    public class PayPlanInfo
    {
        public decimal MaximumClaim { get; set; }
        public decimal MonthlyServiceFee { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal MonthlyTaxAndInsWithheld { get; set; }
        public decimal NetMonthlyPayment { get; set; }
        public string PayPlanType { get; set; }
        public string PaymentStatus { get; set; }
        public bool? PrintStatements { get; set; }
        public bool? ProhibitAllCorrespondence { get; set; }
        public int RemainingPayments { get; set; }
    }
}
