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
    
    public partial class usp_GetSelectListAlertTypeActive_Result
    {
        public Nullable<int> alert_type_skey { get; set; }
        public string alert_type_description { get; set; }
        public Nullable<int> alert_severity_skey { get; set; }
        public Nullable<bool> is_gnma_alert_flag { get; set; }
    }
}