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
    
    public partial class ref_document_type
    {
        public int document_type_skey { get; set; }
        public string document_type_description { get; set; }
        public int document_category_skey { get; set; }
        public bool is_critical_flag { get; set; }
        public Nullable<int> stacking_order { get; set; }
        public bool stacking_separator_sheet_flag { get; set; }
        public string stacking_sheet_description { get; set; }
        public Nullable<int> sort_order_HUD_claim { get; set; }
        public Nullable<int> sort_order_FNMA_571_claim { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}