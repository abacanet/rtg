using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class RateIndexTypeDTO
    {
        public string Description { get; set; }
        public string WebSiteUrl { get; set; }

        public RateIndexTypeDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new RateIndexTypeDTO
            {
                Description = entity.rate_index_type_description,
                WebSiteUrl = entity.website_url
            };
        }
    }
}