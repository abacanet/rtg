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
    
    public partial class app_hmbs_subscriber
    {
        public int hmbs_subscriber_skey { get; set; }
        public int hmbs_pool_skey { get; set; }
        public string hmbs_subscriber_description { get; set; }
        public Nullable<decimal> position_amount { get; set; }
        public string deliver_to { get; set; }
        public string frb_description { get; set; }
        public string aba_number { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}