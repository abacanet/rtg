using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanBoardingStatusDTO : BaseDTO
    {
        public int BatchSkey { get; set; }
        public int BatchStatusSkey { get; set; }
        public string BatchStatusDescription { get; set; }

        public LoanBoardingStatusDTO MapFromEntity(usp_GetLoanBoardingStatus_Result result)
        {
            return new LoanBoardingStatusDTO
            {
                BatchSkey = result.batch_skey,
                BatchStatusDescription = result.batch_status_description,
                BatchStatusSkey = result.batch_status_skey
            };
        }
    }
}