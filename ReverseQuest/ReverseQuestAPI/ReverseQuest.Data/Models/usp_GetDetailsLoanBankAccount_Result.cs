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
    
    public partial class usp_GetDetailsLoanBankAccount_Result
    {
        public int loan_skey { get; set; }
        public string aba_number { get; set; }
        public string account_number { get; set; }
        public string method_of_payment { get; set; }
        public string account_type { get; set; }
        public string status_description { get; set; }
        public string bank_name { get; set; }
        public string bank_phone_number { get; set; }
        public string bank_address1 { get; set; }
        public string bank_address2 { get; set; }
        public string bank_city { get; set; }
        public string bank_state_code { get; set; }
        public string bank_zip_code { get; set; }
        public string unmasked_aba_number { get; set; }
        public string unmasked_account_number { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
