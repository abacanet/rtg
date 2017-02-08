using System;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanNotesSearchDTO : BaseDTO
    {
        public int NoteSkey { get; set; }
        public int LoanSkey { get; set; }
        public string OriginalLoanNumber { get; set; }
        public string PriorServicerLoanNumber { get; set; }
        public string LoanStatus { get; set; }
        public string LoanSubStatus { get; set; }
        public bool? HighImportanceFlag { get; set; }
        public string NoteTypeDescription { get; set; }
        public string NoteTypeCategoryDescription { get; set; }
        public string NoteText { get; set; }
        public string ServicerName { get; set; }
        public string InvestorName { get; set; }
        public string LoanPoolDescription { get; set; }
        public string ProductTypeDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string MersMinNumber { get; set; }
        public string LoanSubStatusCode { get; set; }
        public int? NoteTypeSkey { get; set; }
        public int? NoteTypeCategorySkey { get; set; }
        public int? LoanServicerSkey { get; set; }
        public int? InvestorSkey { get; set; }
        public int? LoanPoolSkey { get; set; }
        public int? ProductTypeSkey { get; set; }
        public int? RecordCount { get; set; }
        public string LoanStatusCode { get; set; }
        public string Filler { get; set; }

        public LoanNotesSearchDTO MapFromEntity(usp_GetResultsLoanNoteSearch_Result entity)
        {
            return new LoanNotesSearchDTO
            {
                LoanSkey = entity.loan_skey,
                LoanPoolSkey = entity.loan_pool_skey,
                LoanStatus = entity.loan_status,
                LoanServicerSkey = entity.loan_servicer_skey,
                OriginalLoanNumber = entity.original_loan_number,
                ProductTypeSkey = entity.product_type_skey,
                LoanSubStatusCode = entity.loan_sub_status_code,
                InvestorSkey = entity.investor_skey,
                CreatedDate = entity.created_date,
                ServicerName = entity.servicer_name,
                ProductTypeDescription = entity.product_type_description,
                CreatedBy = entity.created_by,
                PriorServicerLoanNumber = entity.prior_servicer_loan_number,
                MersMinNumber = entity.mers_min_number,
                InvestorName = entity.investor_name,
                LoanPoolDescription = entity.loan_pool_description,
                Filler = entity.filler,
                LoanSubStatus = entity.loan_sub_status,
                LoanStatusCode = entity.loan_status_code,
                RecordCount = entity.record_count,
                HighImportanceFlag = entity.high_importance_flag,
                NoteSkey = entity.note_skey,
                NoteText = entity.note_text,
                NoteTypeCategoryDescription = entity.note_type_category_description,
                NoteTypeCategorySkey = entity.note_type_category_skey,
                NoteTypeDescription = entity.note_type_description,
                NoteTypeSkey = entity.note_type_skey
            };
        }
    }
}