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
    
    public partial class app_note
    {
        public int note_skey { get; set; }
        public int loan_skey { get; set; }
        public Nullable<int> contact_skey { get; set; }
        public int note_type_skey { get; set; }
        public Nullable<bool> high_importance_flag { get; set; }
        public string note_text { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
