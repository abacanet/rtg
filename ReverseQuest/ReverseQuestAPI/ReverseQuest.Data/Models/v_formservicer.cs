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
    
    public partial class v_formservicer
    {
        public int loan_servicer_skey { get; set; }
        public string servicer_name { get; set; }
        public int client_skey { get; set; }
        public string contact_name { get; set; }
        public string alternate_name { get; set; }
        public string legal_name { get; set; }
        public string legal_name_part1 { get; set; }
        public string legal_name_part2 { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state_code { get; set; }
        public string zip_code { get; set; }
        public Nullable<decimal> main_phone_number { get; set; }
        public Nullable<decimal> alt_phone_number { get; set; }
        public Nullable<decimal> hearing_impaired_number { get; set; }
        public Nullable<decimal> fax_number { get; set; }
        public string email { get; set; }
        public string website_url { get; set; }
        public string check_payable_to { get; set; }
        public string correspondence_dept { get; set; }
        public string correspondence_contact { get; set; }
        public string funds_received_by_time { get; set; }
        public Nullable<int> letter_logo_height { get; set; }
        public Nullable<int> letter_logo_width { get; set; }
        public Nullable<int> report_logo_height { get; set; }
        public Nullable<int> report_logo_width { get; set; }
        public byte[] letter_logo_image { get; set; }
        public byte[] report_logo_image { get; set; }
        public byte[] signature_image { get; set; }
        public string letter_logo_filetype { get; set; }
        public string report_logo_filetype { get; set; }
        public string signature_filetype { get; set; }
        public Nullable<bool> is_prior_servicer_flag { get; set; }
        public string tax_id_number { get; set; }
        public string aba_number { get; set; }
        public string account_number { get; set; }
        public string fha_mortgagee_number { get; set; }
        public string fdic_servicer_skey { get; set; }
        public string fdic_servicer_name { get; set; }
        public string hmbs_issuer_id { get; set; }
        public int status_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
        public int investor_skey { get; set; }
        public Nullable<bool> required_private_label { get; set; }
        public string sub_servicer_name { get; set; }
        public string bank_name { get; set; }
        public string acct_number { get; set; }
        public bool request_funds_in_advance_flag { get; set; }
    }
}
