using System;

namespace ReverseQuest.Classes.Models.LoanModule.LoanDetail
{
    public class LoanRecording
    {
        
        public string AdpCodeSectOfAcct { get; set; }
        public decimal AddtlPgFeeAmt { get; set; }
        public int BookNum { get; set; }
        public DateTime ClosingSignedDate { get; set; }
        public decimal FirstPgRecFeeAmt { get; set; }
        public DateTime FundedDate { get; set; }
        public DateTime FhaCaseNumAssignedDate { get; set; }
        public int InstrumentNum { get; set; }
        public string MersMinNum { get; set; }
        public DateTime MicDate { get; set; }
        public int PageNum { get; set; }
        public DateTime StormSentDate { get; set; }
        public DateTime RecordedDate { get; set; }
        
    }
}
