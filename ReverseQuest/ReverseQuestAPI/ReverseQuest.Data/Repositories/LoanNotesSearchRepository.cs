using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Data.Repositories
{
    public class LoanNotesSearchRepository : IRepository<usp_GetResultsLoanNoteSearch_Result>
    {
        private readonly ReverseQuestEntities _reverseQuestEntities;
        private bool _disposed;

        public LoanNotesSearchRepository(ReverseQuestEntities reverseQuestEntities)
        {
            _reverseQuestEntities = reverseQuestEntities;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _reverseQuestEntities.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<usp_GetResultsLoanNoteSearch_Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public ObjectResult<usp_GetResultsLoanNoteSearch_Result> ExecuteFunctionGet(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<usp_GetResultsLoanNoteSearch_Result> GetCollectionByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            return _reverseQuestEntities.usp_GetResultsLoanNoteSearch(
                parameters["aiLoanSKey"] as int?,
                parameters["avcOriginalLoanNumber"] as string,
                parameters["avcLoanStatus"] as string,
                parameters["avcLoanSubStatusCodes"] as string,
                parameters["avcLoanServicerSKeys"] as string,
                parameters["avcInvestorSKeys"] as string,
                parameters["avcLoanPoolSKeys"] as string,
                parameters["avcProductTypeSKeys"] as string,
                parameters["avcHighImportanceFlag"] as string,
                parameters["avcNoteText"] as string,
                parameters["adtmCreatedDateFrom"] as DateTime?,
                parameters["adtmCreatedDateTo"] as DateTime?,
                parameters["avcCreatedBy"] as string,
                parameters["avcNoteTypeSkeys"] as string,
                parameters["avcNoteTypeCategorySkeys"] as string,
                parameters["aiPageNumber"] as int?,
                parameters["aiNumberOfRecords"] as int?,
                parameters["avcSortColumn"] as string,
                parameters["avcSortOrder"] as string);
        }

        public usp_GetResultsLoanNoteSearch_Result GetEntityByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<usp_GetResultsLoanNoteSearch_Result> FindBy(Expression<Func<usp_GetResultsLoanNoteSearch_Result, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(usp_GetResultsLoanNoteSearch_Result entity, params object[] ids)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
