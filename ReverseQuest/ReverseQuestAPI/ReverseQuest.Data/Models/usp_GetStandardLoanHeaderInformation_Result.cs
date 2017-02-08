//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReverseQuest.Data.Models
{
    using System;
    
    public partial class usp_GetStandardLoanHeaderInformation_Result
    {
        public int loan_skey { get; set; }
        public string original_loan_number { get; set; }
        public string fha_case_number { get; set; }
        public string investor_loan_number { get; set; }
        public string ginnie_mae_number { get; set; }
        public string loan_sub_status_description { get; set; }
        public string product_type_description { get; set; }
        public string formatted_property_address { get; set; }
        public string formatted_contact_name { get; set; }
        public string formatted_borrower_address { get; set; }
        public string borrower_address1 { get; set; }
        public string borrower_address2 { get; set; }
        public string borrower_city { get; set; }
        public string borrower_state_code { get; set; }
        public string borrower_zip_code { get; set; }
        public string borrower_home_phone_number { get; set; }
        public string borrower_work_phone_number { get; set; }
        public string loan_status { get; set; }
        public string investor_name { get; set; }
        public string servicer_name { get; set; }
        public string loan_pool_long_description { get; set; }
        public string property_type_category_description { get; set; }
        public decimal monthly_principal_amount { get; set; }
        public string payment_plan_description { get; set; }
        public Nullable<decimal> maximum_claim_amount { get; set; }
        public int payment_plan_type { get; set; }
        public string loan_sub_status_code { get; set; }
        public int product_type_skey { get; set; }
        public int contact_skey { get; set; }
        public int investor_skey { get; set; }
        public int loan_servicer_skey { get; set; }
        public int loan_pool_skey { get; set; }
        public int property_type_category_skey { get; set; }
        public string boarding_type { get; set; }
        public string credit_type { get; set; }
    }
}