using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects
{
    public class LifeExpectancySetAside
    {
        public int? Type { get; set; }
        public string TypeDescription { get; set; }
        public decimal? SemiannualAmount { get; set; }
        public int? PaymentStatusSkey { get; set; }
        public string PaymentStatusDescription { get; set; }
        public decimal? FirstYearTaxInsuranceAmount { get; set; }
        public decimal? Balance { get; set; }

        public LifeExpectancySetAside MapFromEntity(usp_GetDetailsLoanBalances_Result entity)
        {
            return new LifeExpectancySetAside
            {
                Type = entity.LESA_type,
                TypeDescription = entity.LESA_type_description,
                Balance = entity.LESA_balance,
                FirstYearTaxInsuranceAmount = entity.LESA_first_year_tax_insurance_amount,
                PaymentStatusDescription = entity.LESA_payment_status_description,
                PaymentStatusSkey = entity.LESA_payment_status_skey,
                SemiannualAmount = entity.LESA_semiannual_amount
            };
        }
    }
}