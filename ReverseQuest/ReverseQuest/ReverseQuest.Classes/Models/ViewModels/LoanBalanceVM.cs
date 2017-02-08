using ReverseQuest.Classes.Models.LoanModule.LoanBalance;

namespace ReverseQuest.Classes.Models.ViewModels
{
    public class LoanBalanceVM
    {
        public CredLisaInfo CredLisaInfo { get; set; }
        public InitCredLisaInfo InitCredLisaInfo { get; set; }
        public InitDisbLimit InitDisbLimit { get; set; }
        public LifeExpectancySetAside LifeExpectancySetAside { get; set; }
        public PayPlanInfo PayPlanInfo { get; set; }
        public PrincipalLimitCalculation PrincipalLimitCalc { get; set;}
        public OtherBalances OtherBalance { get; set; }
    }
}
