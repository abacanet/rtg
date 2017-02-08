using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class CountyClerkDTO
    {
        public decimal? AditionalPageFeeAmount { get; set; }

        public CountyClerkDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new CountyClerkDTO
            {
                AditionalPageFeeAmount = entity.additional_page_fee_amt
            };
        }
    }
}