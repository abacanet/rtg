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
    
    public partial class usp_GetResultsLoanNoteSearch_Result
    {
        public int note_skey { get; set; }
        public int loan_skey { get; set; }
        public string original_loan_number { get; set; }
        public string prior_servicer_loan_number { get; set; }
        public string loan_status { get; set; }
        public string loan_sub_status { get; set; }
        public Nullable<bool> high_importance_flag { get; set; }
        public string note_type_description { get; set; }
        public string note_type_category_description { get; set; }
        public string note_text { get; set; }
        public string servicer_name { get; set; }
        public string investor_name { get; set; }
        public string loan_pool_description { get; set; }
        public string product_type_description { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string mers_min_number { get; set; }
        public string loan_sub_status_code { get; set; }
        public Nullable<int> note_type_skey { get; set; }
        public Nullable<int> note_type_category_skey { get; set; }
        public Nullable<int> loan_servicer_skey { get; set; }
        public Nullable<int> investor_skey { get; set; }
        public Nullable<int> loan_pool_skey { get; set; }
        public Nullable<int> product_type_skey { get; set; }
        public Nullable<int> record_count { get; set; }
        public string loan_status_code { get; set; }
        public string filler { get; set; }
    }
}