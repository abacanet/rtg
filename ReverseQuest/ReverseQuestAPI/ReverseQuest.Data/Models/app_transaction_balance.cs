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
    
    public partial class app_transaction_balance
    {
        public long transaction_balance_skey { get; set; }
        public int loan_skey { get; set; }
        public string transaction_code { get; set; }
        public System.DateTime transaction_date { get; set; }
        public System.DateTime effective_date { get; set; }
        public decimal principal_amount { get; set; }
        public decimal interest_amount { get; set; }
        public decimal mip_amount { get; set; }
        public decimal service_fee_amount { get; set; }
        public decimal unscheduled_disbursement_accrual_amount { get; set; }
        public decimal corporate_advance_borrower_amount { get; set; }
        public Nullable<decimal> corporate_advance_investor_amount { get; set; }
        public decimal servicer_expense_amount { get; set; }
        public decimal overage_amount { get; set; }
        public decimal debenture_interest_dnp_upb_amount { get; set; }
        public decimal debenture_interest_other_amount { get; set; }
        public Nullable<int> disbursement_skey { get; set; }
        public Nullable<int> servicing_management_skey { get; set; }
        public long transaction_group_id { get; set; }
        public long reference_transaction_group_id { get; set; }
        public Nullable<System.DateTime> eboutique_sent_date { get; set; }
        public Nullable<System.DateTime> HUD_sent_date { get; set; }
        public Nullable<decimal> interest_rate { get; set; }
        public Nullable<int> transaction_adjustment_reason_skey { get; set; }
        public Nullable<long> invoice_attachment_skey { get; set; }
        public Nullable<long> check_attachment_skey { get; set; }
        public System.DateTime created_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<int> workflow_instance_skey { get; set; }
        public Nullable<long> invoice_document_skey { get; set; }
        public Nullable<long> check_document_skey { get; set; }
    }
}