using System;
using System.Collections.Generic;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanPropertyValueDTO : BaseDTO
    {
        public int LoanSkey { get; set; }
        public string PropertyValueTypeDescription { get; set; }
        public string PropertyValueSubTypeDescription { get; set; }
        public DateTime? PropertyValueDate { get; set; }
        public decimal? EstimatedPropertyValue { get; set; }
        public decimal? RepairedPropertyValue { get; set; }
        public string ValuatorName { get; set; }
        public string StatusDescription { get; set; }
        public int PropertyValueSkey { get; set; }
        public int PropertyValueTypeSkey { get; set; }
        public int PropertyValueSubTypeSkey { get; set; }
        public int? ValuatorSkey { get; set; }
        public int StatusSkey { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public LoanPropertyValueDTO MapFromEntity(usp_GetDetailsLoanPropertyValues_Result entity)
        {
            return new LoanPropertyValueDTO
            {
                LoanSkey = entity.loan_skey,
                CreatedDate = entity.created_date,
                CreatedBy = entity.created_by,
                ModifiedBy = entity.modified_by,
                ModifiedDate = entity.modified_date,
                StatusSkey = entity.status_skey,
                EstimatedPropertyValue = entity.estimated_property_value,
                PropertyValueDate = entity.property_value_date,
                PropertyValueSkey = entity.property_value_skey,
                PropertyValueSubTypeDescription = entity.property_value_sub_type_description,
                PropertyValueSubTypeSkey = entity.property_value_sub_type_skey,
                PropertyValueTypeDescription = entity.property_value_type_description,
                PropertyValueTypeSkey = entity.property_value_type_skey,
                RepairedPropertyValue = entity.repaired_property_value,
                StatusDescription = entity.status_description,
                ValuatorName = entity.valuator_name,
                ValuatorSkey = entity.valuator_skey
            };
        }

        public Dictionary<string, object> MapToDictionary()
        {
            return new Dictionary<string, object>
            {
                {"ai_PropertyValueSkey", PropertyValueSkey},
                {"ai_LoanSkey", LoanSkey},
                {"ai_PropertyValueTypeSkey", PropertyValueTypeSkey},
                {"ai_PropertyValueSubTypeSkey", PropertyValueSubTypeSkey},
                {"adtm_PropertyValueDate", PropertyValueDate},
                {"am_EstimatedPropertyValue", EstimatedPropertyValue},
                {"am_RepairedPropertyValue", RepairedPropertyValue},
                {"ai_StatusSkey", StatusSkey},
                {"ai_valuatorSkey", ValuatorSkey}
            };
        }
    }
}