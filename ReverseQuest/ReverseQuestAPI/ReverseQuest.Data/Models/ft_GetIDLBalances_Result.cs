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
    
    public partial class ft_GetIDLBalances_Result
    {
        public Nullable<int> loan_skey { get; set; }
        public Nullable<int> payment_plan_type { get; set; }
        public Nullable<decimal> IDL_amount { get; set; }
        public Nullable<System.DateTime> IDL_Expiration_Date { get; set; }
        public Nullable<int> IDL_Remaining_Months { get; set; }
        public Nullable<int> IDL_payments_remain { get; set; }
        public Nullable<decimal> IDL_scheduled_payment_remaining_amount { get; set; }
    }
}