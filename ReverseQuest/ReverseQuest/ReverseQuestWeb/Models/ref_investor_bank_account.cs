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
    
    public partial class ref_investor_bank_account
    {
        public int investor_bank_account_skey { get; set; }
        public string aba_number { get; set; }
        public string account_number { get; set; }
        public Nullable<int> check_number { get; set; }
        public string fractional_numerator { get; set; }
        public string fractional_denominator { get; set; }
        public Nullable<bool> use_for_loss_drafts_flag { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
