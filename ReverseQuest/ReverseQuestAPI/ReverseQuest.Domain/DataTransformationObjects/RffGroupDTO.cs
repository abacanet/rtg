using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class RffGroupDTO
    {
        public string Description { get; set; }

        public RffGroupDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new RffGroupDTO
            {
                Description = entity.rff_group_desc
            };
        }
    }
}