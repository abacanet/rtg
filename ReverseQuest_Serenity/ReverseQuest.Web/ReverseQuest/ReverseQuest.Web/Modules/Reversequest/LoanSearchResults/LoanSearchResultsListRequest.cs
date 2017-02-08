namespace ReverseQuest.LoanSearchListRequest
{
    using Serenity.Services;
    using System;

    public class LoanSearchResultsListRequest : ListRequest
    {

        public Int32? Loan_Skey { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
    }
}