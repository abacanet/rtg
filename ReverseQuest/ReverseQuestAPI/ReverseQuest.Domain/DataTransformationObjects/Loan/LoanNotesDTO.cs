using System;
using System.Collections.Generic;
using ReverseQuest.Data.Models;

namespace ReverseQuest.Domain.DataTransformationObjects.Loan
{
    public class LoanNotesDTO : BaseDTO
    {
        public int? NoteSkey { get; set; }
        public int? LoanSkey { get; set; }
        public int? ContactSkey { get; set; }
        public bool? HighImportanceFlag { get; set; }
        public string NoteText { get; set; }
        public int? NoteTypeSkey { get; set; }
        public string NoteTypeDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ModifiedDate1 { get; set; }

        public LoanNotesDTO MapFromEntity(usp_GetDetailsLoanNotes_Result entity)
        {
            return new LoanNotesDTO
            {
                LoanSkey = entity.loan_skey,
                HighImportanceFlag = entity.high_importance_flag,
                NoteSkey = entity.note_skey,
                NoteText = entity.note_text,
                NoteTypeSkey = entity.note_type_skey,
                CreatedBy = entity.created_by,
                CreatedDate = entity.created_date,
                ModifiedDate = entity.modified_date,
                NoteTypeDescription = entity.note_type_description
            };
        }

        public Dictionary<string, object> MapToDictionary()
        {
            return new Dictionary<string, object>
            {
                {"ai_LoanSkey", LoanSkey},
                {"ai_NoteSkey", NoteSkey},
                {"ai_ContactSkey", ContactSkey},
                {"ab_HighImportanceFlag", HighImportanceFlag},
                {"avc_NoteText", NoteText},
                {"ai_NoteTypeSkey", NoteTypeSkey}
            };
        }
    }
}