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
    using System.Collections.Generic;
    
    public partial class ref_loan_boarding_validation_rules
    {
        public int validation_code { get; set; }
        public string validation_message { get; set; }
        public Nullable<bool> is_custom_validation_flag { get; set; }
        public string validation_type { get; set; }
        public string column_type { get; set; }
        public Nullable<bool> allow_null_flag { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
