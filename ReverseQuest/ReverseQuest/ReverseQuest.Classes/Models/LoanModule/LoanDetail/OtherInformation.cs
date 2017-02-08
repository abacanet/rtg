using System;

namespace ReverseQuest.Classes.Models.LoanModule.LoanDetail
{
    public class OtherInformation
    {
        public DateTime BoardedDate { get; set; }
        public string BoardingType { get; set; }
        public string CreditType { get; set; }
        public int LoanChannelSkey { get; set; }
        public string LoanChannel { get; set; }
        public int LoanOriginatorSkey { get; set; }
        public string LoanOriginator { get; set; }
    }
}
