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
    
    public partial class app_batch_header
    {
        public int batch_skey { get; set; }
        public int batch_type_skey { get; set; }
        public int batch_status_skey { get; set; }
        public Nullable<byte> balance_attempt_count { get; set; }
        public Nullable<System.DateTime> balanced_date { get; set; }
        public string balanced_by { get; set; }
        public Nullable<System.DateTime> bank_export_date { get; set; }
        public string bank_export_by { get; set; }
        public Nullable<System.DateTime> gl_export_date { get; set; }
        public string gl_export_by { get; set; }
        public Nullable<System.DateTime> sap_export_date { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<int> loan_servicer_skey { get; set; }
        public Nullable<int> investor_skey { get; set; }
        public Nullable<int> loan_pool_skey { get; set; }
        public Nullable<int> property_type_category_skey { get; set; }
        public string boarding_type { get; set; }
        public string file_name { get; set; }
    }
}
