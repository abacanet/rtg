using System;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class PaymentPlanTypeDTO
    {
        public long? Type { get; set; }
        public string PaymentPlanDescription { get; set; }
        public string HmbsPaymentOption { get; set; }
        public long? StatusSkey { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        public PaymentPlanTypeDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new PaymentPlanTypeDTO
            {
                PaymentPlanDescription = entity.payment_plan_description
            };
        }

        public PaymentPlanTypeDTO MapFromEntity(usp_GetDetailsLoanBalances_Result entity)
        {
            return new PaymentPlanTypeDTO
            {
                Type = entity.payment_plan_type,
                PaymentPlanDescription = entity.payment_plan_description
            };
        }
    }
}