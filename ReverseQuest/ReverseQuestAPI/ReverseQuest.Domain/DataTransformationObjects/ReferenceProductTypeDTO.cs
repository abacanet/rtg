using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class ReferenceProductTypeDTO
    {
        public string ProductTypeDescription { get; set; }

        public ReferenceProductTypeDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new ReferenceProductTypeDTO
            {
                ProductTypeDescription = entity.product_type_description
            };
        }
    }
}