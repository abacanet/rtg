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
    
    public partial class ref_bankruptcy_district
    {
        public int bankruptcy_district_skey { get; set; }
        public string state_code { get; set; }
        public string bankruptcy_district_name { get; set; }
        public string mail_to { get; set; }
        public string mail_contact_name { get; set; }
        public string mail_address1 { get; set; }
        public string mail_address2 { get; set; }
        public string mail_city { get; set; }
        public string mail_state_code { get; set; }
        public string mail_zip_code { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
