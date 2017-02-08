using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class ArmTypeDTO
    {
        public string Description { get; set; }

        public ArmTypeDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new ArmTypeDTO
            {
                Description = entity.arm_type_description
            };
        }
    }
}