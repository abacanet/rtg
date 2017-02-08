using System;

namespace ReverseQuest.Classes.Models.LoanModule.LoanBalance
{
    public class InitDisbLimit
    {
        public decimal FirstYearLesaTaxAndIns { get; set; }
        public decimal FirstYearSetAside { get; set; }
        public decimal OtherSetAside { get; set; }
        public decimal Idl { get; set; }
        public DateTime IdlExpirationDate { get; set; }
        public decimal InitialCreditLisa { get; set; }
        public decimal InitialNetPrincipalLimit { get; set; }
        public decimal NetGrowth { get; set; }
        public decimal PrinBalAndInitMip { get; set; }
        public decimal RepairSetAside { get; set; }
    }
}
