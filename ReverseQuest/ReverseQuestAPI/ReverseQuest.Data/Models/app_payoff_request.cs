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
    
    public partial class app_payoff_request
    {
        public int payoff_request_skey { get; set; }
        public int loan_servicer_skey { get; set; }
        public int investor_skey { get; set; }
        public int loan_pool_skey { get; set; }
        public int loan_skey { get; set; }
        public string loan_number { get; set; }
        public System.DateTime payoff_date { get; set; }
        public decimal payoff_amount { get; set; }
        public Nullable<decimal> perdiem { get; set; }
        public string borrower_skey { get; set; }
        public string requestor_skey { get; set; }
        public Nullable<int> property_skey { get; set; }
        public Nullable<int> status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
