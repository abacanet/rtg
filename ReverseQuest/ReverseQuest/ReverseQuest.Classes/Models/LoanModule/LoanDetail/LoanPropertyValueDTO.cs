using System;
using System.Collections.Generic;


namespace ReverseQuest.API.DataTransformationObjects.Loan
{
    public class LoanPropertyValueDTO : BaseLoanDTO
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

    }
}