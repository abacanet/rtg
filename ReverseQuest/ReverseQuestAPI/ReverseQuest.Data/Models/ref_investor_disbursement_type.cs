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
    
    public partial class ref_investor_disbursement_type
    {
        public int investor_disbursement_type_skey { get; set; }
        public int investor_skey { get; set; }
        public int disbursement_type_skey { get; set; }
        public int investor_bank_account_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
