using System;

namespace ReverseQuest.Classes.Models.LoanModule.LoanDetail
{
    public class LoanFiling
    {
        public long HermitSKey { get; set; }
        public string LoanManager { get; set; }
        public long Spoc { get; set; }
        public DateTime PayOffDate { get; set; }
        public string MersMinNum { get; set; }
    }
}
