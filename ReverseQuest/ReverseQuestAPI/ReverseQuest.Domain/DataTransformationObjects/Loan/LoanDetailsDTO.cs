namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanDetailsDTO : BaseDTO
    {
        public LoanMasterDTO LoanMasterDTO { get; set; }
        public LoanRatesDTO LoanRatesDTO { get; set; }
        public LoanServicerDTO LoanServicerDTO { get; set; }
        public LoanSubStatusDTO LoanSubStatusDTO { get; set; }
        public ReferenceProductTypeDTO ReferenceProductTypeDTO { get; set; }
        public PaymentPlanTypeDTO PaymentPlanTypeDTO { get; set; }
        public PaymentDTO PaymentDTO { get; set; }
        public ArmTypeDTO ArmTypeDTO { get; set; }
        public RateIndexTypeDTO RateIndexTypeDTO { get; set; }
        public RffGroupDTO RffGroupDTO { get; set; }
        public CountyClerkDTO CountyClerkDTO { get; set; }
    }
}