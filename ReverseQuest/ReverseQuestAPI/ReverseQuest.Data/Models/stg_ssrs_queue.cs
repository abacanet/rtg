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
    
    public partial class stg_ssrs_queue
    {
        public int ssrs_queue_skey { get; set; }
        public int ssrs_report_skey { get; set; }
        public int loan_skey { get; set; }
        public Nullable<int> contact_skey { get; set; }
        public string property_state_code { get; set; }
        public Nullable<int> servicing_activity_skey { get; set; }
        public string ssrs_report_name { get; set; }
        public Nullable<bool> is_spanish_flag { get; set; }
        public Nullable<bool> is_auto_flag { get; set; }
        public Nullable<int> processed_flag { get; set; }
        public Nullable<int> document_type_skey { get; set; }
        public string attachment_file_name { get; set; }
        public Nullable<int> attachment_skey { get; set; }
    }
}