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
    
    public partial class log_loan_boarding_message
    {
        public int loan_boarding_message_skey { get; set; }
        public int batch_skey { get; set; }
        public Nullable<int> loan_boarding_skey { get; set; }
        public string original_loan_number { get; set; }
        public string borrower_name { get; set; }
        public string comments { get; set; }
        public string indicator { get; set; }
        public Nullable<int> servicer_skey { get; set; }
        public Nullable<int> investor_skey { get; set; }
        public Nullable<int> loan_pool_skey { get; set; }
        public Nullable<int> loan_skey { get; set; }
        public Nullable<int> error_code { get; set; }
        public string created_by { get; set; }
        public System.DateTime created_date { get; set; }
    }
}
