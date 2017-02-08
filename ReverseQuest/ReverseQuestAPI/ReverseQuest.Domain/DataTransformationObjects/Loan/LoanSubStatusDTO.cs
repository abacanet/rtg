using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanSubStatusDTO
    {
        public string SubStatusDescription { get; set; }

        public LoanSubStatusDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new LoanSubStatusDTO
            {
                SubStatusDescription = entity.loan_sub_status_description
            };
        }
    }
}