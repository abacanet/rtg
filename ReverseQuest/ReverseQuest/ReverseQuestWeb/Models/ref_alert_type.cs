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
    
    public partial class ref_alert_type
    {
        public int alert_type_skey { get; set; }
        public string alert_type_description { get; set; }
        public int alert_severity_skey { get; set; }
        public Nullable<int> client_skey { get; set; }
        public Nullable<bool> allow_status_change_flag { get; set; }
        public Nullable<bool> is_gnma_alert_flag { get; set; }
        public string loan_sub_status_code { get; set; }
        public string default_note_text { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}