using System;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanQCSearchDTO : BaseDTO
    {
        public int LoanSkey { get; set; }
        public string OriginalLoanNumber { get; set; }
        public string FhaCaseNumber { get; set; }
        public string PriorServicerLoanNumber { get; set; }
        public string InvestorLoanNumber { get; set; }
        public string LoanStatus { get; set; }
        public string LoanSubStatus { get; set; }
        public string BorrowerFirstName { get; set; }
        public string BorrowerLastName { get; set; }
        public string CoborrowerFirstName { get; set; }
        public string CoborrowerLastName { get; set; }
        public string BorrowerPhoneNumber { get; set; }
        public string EnbsFirstName { get; set; }
        public string EnbsLastName { get; set; }
        public string PropertyAddress1 { get; set; }
        public string PropertyAddress2 { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyCounty { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZipcode { get; set; }
        public string ServicerName { get; set; }
        public string InvestorName { get; set; }
        public string LoanPoolDescription { get; set; }
        public string ProductTypeDescription { get; set; }
        public string PaymentPlanTypeDescription { get; set; }
        public string ArmTypeDescription { get; set; }
        public string RateIndexTypeDescription { get; set; }
        public string BoardedBy { get; set; }
        public DateTime? BoardedDate { get; set; }
        public string BoardingTypeDescription { get; set; }
        public string CreditTypeDescription { get; set; }
        public string MersMinNumber { get; set; }
        public string LoanSubStatusCode { get; set; }
        public int? LoanServicerSkey { get; set; }
        public int? InvestorSkey { get; set; }
        public int? LoanPoolSkey { get; set; }
        public int? ProductTypeSkey { get; set; }
        public int? PaymentPlanType { get; set; }
        public string ArmType { get; set; }
        public int? RateIndexTypeSkey { get; set; }
        public string BoardingType { get; set; }
        public string CreditType { get; set; }
        public int? RecordCount { get; set; }
        public string LoanStatusCode { get; set; }
        public string Filler { get; set; }
        public string LoanManagerName { get; set; }
        public string LoanManagerId { get; set; }

        public LoanQCSearchDTO MapFromEntity(usp_GetResultsLoanQCSearch_Result entity)
        {
            return new LoanQCSearchDTO
            {
                PaymentPlanType = entity.payment_plan_type,
                LoanSkey = entity.loan_skey,
                ArmType = entity.arm_type,
                CreditTypeDescription = entity.credit_type_description,
                BoardingTypeDescription = entity.boarding_type_description,
                InvestorSkey = entity.investor_skey,
                ProductTypeSkey = entity.product_type_skey,
                OriginalLoanNumber = entity.original_loan_number,
                LoanServicerSkey = entity.loan_servicer_skey,
                LoanStatus = entity.loan_status,
                InvestorLoanNumber = entity.investor_loan_number,
                MersMinNumber = entity.mers_min_number,
                BoardingType = entity.boarding_type,
                PriorServicerLoanNumber = entity.prior_servicer_loan_number,
                LoanPoolSkey = entity.loan_pool_skey,
                RateIndexTypeSkey = entity.rate_index_type_skey,
                CreditType = entity.credit_type,
                LoanSubStatusCode = entity.loan_sub_status_code,
                FhaCaseNumber = entity.fha_case_number,
                ServicerName = entity.servicer_name,
                ProductTypeDescription = entity.product_type_description,
                ArmTypeDescription = entity.arm_type_description,
                BoardedBy = entity.boarded_by,
                BoardedDate = entity.boarded_date,
                BorrowerFirstName = entity.borrower_first_name,
                BorrowerLastName = entity.borrower_last_name,
                BorrowerPhoneNumber = entity.borrower_phone_number,
                CoborrowerFirstName = entity.coborrower_first_name,
                CoborrowerLastName = entity.coborrower_last_name,
                EnbsFirstName = entity.enbs_first_name,
                EnbsLastName = entity.enbs_last_name,
                Filler = entity.filler,
                InvestorName = entity.investor_name,
                LoanPoolDescription = entity.loan_pool_description,
                LoanStatusCode = entity.loan_status_code,
                LoanSubStatus = entity.loan_sub_status,
                PaymentPlanTypeDescription = entity.payment_plan_type_description,
                PropertyAddress1 = entity.property_address1,
                PropertyAddress2 = entity.property_address2,
                PropertyCity = entity.property_city,
                PropertyCounty = entity.property_county,
                PropertyState = entity.property_state,
                PropertyZipcode = entity.property_zipcode,
                RateIndexTypeDescription = entity.rate_index_type_description,
                RecordCount = entity.record_count,
                LoanManagerId = entity.loan_manager_id,
                LoanManagerName = entity.loan_manager_name
            };
        }
    }
}