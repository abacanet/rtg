using System;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanBoardingResultDTO : BaseDTO
    {
        public int BatchSkey { get; set; }
        public string OriginalLoanNumber { get; set; }
        public int LoanBoardingSkey { get; set; }
        public string BorrowerName { get; set; }
        public int? BoardedFlag { get; set; }
        public string Comments { get; set; }
        public string Indicator { get; set; }
        public int? ErrorCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public LoanBoardingResultDTO MapFromEntity(usp_GetListLoanBoardingResult_Result result)
        {
            return new LoanBoardingResultDTO
            {
                CreatedDate = result.created_date,
                CreatedBy = result.created_by,
                OriginalLoanNumber = result.original_loan_number,
                BatchSkey = result.batch_skey,
                BoardedFlag = result.boarded_flag,
                BorrowerName = result.borrower_name,
                Comments = result.comments,
                ErrorCode = result.error_code,
                Indicator = result.indicator,
                LoanBoardingSkey = result.loan_boarding_skey
            };
        }
    }
}