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
    
    public partial class usp_GetListLoanBoardingResult_Result
    {
        public int batch_skey { get; set; }
        public string original_loan_number { get; set; }
        public int loan_boarding_skey { get; set; }
        public string borrower_name { get; set; }
        public Nullable<int> boarded_flag { get; set; }
        public string comments { get; set; }
        public string indicator { get; set; }
        public Nullable<int> error_code { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
    }
}
