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
    
    public partial class app_transaction_growth
    {
        public long transaction_growth_skey { get; set; }
        public int loan_skey { get; set; }
        public string transaction_code { get; set; }
        public System.DateTime transaction_date { get; set; }
        public System.DateTime effective_date { get; set; }
        public decimal principal_limit_amount { get; set; }
        public decimal credit_line_amount { get; set; }
        public long transaction_group_id { get; set; }
        public long reference_transaction_group_id { get; set; }
        public Nullable<decimal> growth_rate { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
