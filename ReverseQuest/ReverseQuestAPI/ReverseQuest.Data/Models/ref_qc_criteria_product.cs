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
    
    public partial class ref_qc_criteria_product
    {
        public int qc_criteria_product_skey { get; set; }
        public int product_type_skey { get; set; }
        public string boarding_type { get; set; }
        public int qc_criteria_skey { get; set; }
        public Nullable<int> primary_qc_document_type_skey { get; set; }
        public Nullable<int> secondary_qc_document_type_skey { get; set; }
        public bool display_document_source_flag { get; set; }
        public Nullable<bool> required_flag { get; set; }
        public Nullable<bool> is_enabled_flag { get; set; }
        public bool pre_populate_flag { get; set; }
        public Nullable<bool> validate_flag { get; set; }
        public Nullable<int> sequence_number { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
