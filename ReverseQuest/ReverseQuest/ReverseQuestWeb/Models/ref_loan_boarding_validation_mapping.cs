//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReverseQuestWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ref_loan_boarding_validation_mapping
    {
        public int loan_boarding_validation_skey { get; set; }
        public int product_type_skey { get; set; }
        public string boarding_type { get; set; }
        public Nullable<int> validation_code { get; set; }
        public Nullable<bool> allow_null_flag { get; set; }
        public Nullable<bool> allow_empty_flag { get; set; }
        public Nullable<bool> allow_zero_flag { get; set; }
        public Nullable<bool> allow_negative_flag { get; set; }
        public Nullable<bool> allow_hyphen_flag { get; set; }
        public Nullable<bool> allow_positive_flag { get; set; }
        public Nullable<int> minimum_length { get; set; }
        public Nullable<int> maximum_length { get; set; }
        public string validation_type { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
