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
    
    public partial class ref_workflow_task
    {
        public int workflow_task_skey { get; set; }
        public string workflow_task_description { get; set; }
        public int workflow_type_skey { get; set; }
        public Nullable<int> workflow_task_category_skey { get; set; }
        public string state_code { get; set; }
        public bool is_critical_task_flag { get; set; }
        public string curtailment_field { get; set; }
        public bool affects_due_date_flag { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
