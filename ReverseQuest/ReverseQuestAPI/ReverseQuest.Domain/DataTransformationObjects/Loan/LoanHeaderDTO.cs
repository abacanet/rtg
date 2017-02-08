using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanHeaderDTO : BaseDTO
    {
        public int LoanSkey { get; set; }
        public string OriginalLoanNumber { get; set; }
        public string FhaCaseNumber { get; set; }
        public string InvestorLoanNumber { get; set; }
        public string GinnieMaeNumber { get; set; }
        public string LoanSubStatusDescription { get; set; }
        public string ProductTypeDescription { get; set; }
        public string FormattedPropertyAddress { get; set; }
        public string FormattedContactName { get; set; }
        public string FormattedBorrowerAddress { get; set; }
        public string BorrowerAddress1 { get; set; }
        public string BorrowerAddress2 { get; set; }
        public string BorrowerCity { get; set; }
        public string BorrowerStateCode { get; set; }
        public string BorrowerZipCode { get; set; }
        public string BorrowerHomePhoneNumber { get; set; }
        public string BorrowerWorkPhoneNumber { get; set; }
        public string LoanStatus { get; set; }
        public string InvestorName { get; set; }
        public string ServicerName { get; set; }
        public string LoanPoolLongDescription { get; set; }
        public string PropertyTypeCategoryDescription { get; set; }
        public decimal MonthlyPrincipalAmount { get; set; }
        public string PaymentPlanDescription { get; set; }
        public decimal? MaximumClaimAmount { get; set; }
        public int PaymentPlanType { get; set; }
        public string LoanSubStatusCode { get; set; }
        public int ProductTypeSkey { get; set; }
        public int ContactSkey { get; set; }
        public int InvestorSkey { get; set; }
        public int LoanServicerSkey { get; set; }
        public int LoanPoolSkey { get; set; }
        public int PropertyTypeCategorySkey { get; set; }
        public string BoardingType { get; set; }
        public string CreditType { get; set; }

        public LoanHeaderDTO MapFromEntity(usp_GetStandardLoanHeaderInformation_Result result)
        {
            return new LoanHeaderDTO
            {
                PaymentPlanType = result.payment_plan_type,
                LoanSkey = result.loan_skey,
                PaymentPlanDescription = result.payment_plan_description,
                InvestorSkey = result.investor_skey,
                BoardingType = result.boarding_type,
                LoanServicerSkey = result.loan_servicer_skey,
                LoanStatus = result.loan_status,
                MonthlyPrincipalAmount = result.monthly_principal_amount,
                InvestorLoanNumber = result.investor_loan_number,
                MaximumClaimAmount = result.maximum_claim_amount,
                OriginalLoanNumber = result.original_loan_number,
                LoanSubStatusCode = result.loan_sub_status_code,
                ProductTypeSkey = result.product_type_skey,
                LoanPoolSkey = result.loan_pool_skey,
                CreditType = result.credit_type,
                FhaCaseNumber = result.fha_case_number,
                ServicerName = result.servicer_name,
                ProductTypeDescription = result.product_type_description,
                InvestorName = result.investor_name,
                GinnieMaeNumber = result.ginnie_mae_number,
                BorrowerAddress1 = result.borrower_address1,
                BorrowerAddress2 = result.borrower_address2,
                BorrowerCity = result.borrower_city,
                BorrowerHomePhoneNumber = result.borrower_home_phone_number,
                BorrowerStateCode = result.borrower_state_code,
                BorrowerWorkPhoneNumber = result.borrower_work_phone_number,
                BorrowerZipCode = result.borrower_zip_code,
                ContactSkey = result.contact_skey,
                FormattedBorrowerAddress = result.formatted_borrower_address,
                FormattedContactName = result.formatted_contact_name,
                FormattedPropertyAddress = result.formatted_property_address,
                LoanPoolLongDescription = result.loan_pool_long_description,
                LoanSubStatusDescription = result.loan_sub_status_description,
                PropertyTypeCategoryDescription = result.product_type_description,
                PropertyTypeCategorySkey = result.property_type_category_skey
            };
        }
    }
}