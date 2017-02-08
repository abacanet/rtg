using ReverseQuest.Classes.Models.LoanModule.LoanDetail;

namespace ReverseQuest.Classes.Models.ViewModels
{
    public class LoanDetailVM
    {
        public LoanFiling LoanFiling { get; set; }
        public LoanRate LoanRate { get; set; }
        public LoanRecording LoanRecording { get; set; }
        public OtherInformation OtherInformation { get; set; }
        public PriorServicerInfo PriorServicerInfo { get; set; }
    }
}