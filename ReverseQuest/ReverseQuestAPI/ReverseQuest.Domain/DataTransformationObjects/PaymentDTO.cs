using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class PaymentDTO
    {
        public decimal? PaymentsRemain { get; set; }
        public long? PaymentStatusSkey { get; set; }
        public string PaymentStatusDescription { get; set; }

        public PaymentDTO MapFromEntity(usp_GetDetailsLoanDetails_Result entity)
        {
            return new PaymentDTO
            {
                PaymentStatusDescription = entity.payment_status_description
            };
        }

        public PaymentDTO MapFromEntity(usp_GetDetailsLoanBalances_Result entity)
        {
            return new PaymentDTO
            {
                PaymentStatusSkey = entity.payment_status_skey,
                PaymentStatusDescription = entity.payment_status_description,
                PaymentsRemain = entity.payments_remain
            };
        }
    }
}