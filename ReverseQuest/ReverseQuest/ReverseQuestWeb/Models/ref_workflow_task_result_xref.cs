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
    
    public partial class ref_workflow_task_result_xref
    {
        public int workflow_task_skey { get; set; }
        public int workflow_task_result_skey { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
