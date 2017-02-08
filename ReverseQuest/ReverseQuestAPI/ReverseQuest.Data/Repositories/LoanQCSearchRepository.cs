using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Data.Repositories
{
    public class LoanQCSearchRepository : IRepository<usp_GetResultsLoanQCSearch_Result>
    {
        private readonly ReverseQuestEntities _reverseQuestEntities;
        private bool _disposed;

        public LoanQCSearchRepository(ReverseQuestEntities reverseQuestEntities)
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

        public IQueryable<usp_GetResultsLoanQCSearch_Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public ObjectResult<usp_GetResultsLoanQCSearch_Result> ExecuteFunctionGet(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<usp_GetResultsLoanQCSearch_Result> GetCollectionByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            return _reverseQuestEntities.usp_GetResultsLoanQCSearch(
                parameters["aiLoanSKey"] as int?,
                parameters["avcOriginalLoanNumber"] as string,
                parameters["avcFhaCaseNumber"] as string,
                parameters["avcInvestorLoanNumber"] as string,
                parameters["avcPriorServicerLoanNumber"] as string,
                parameters["avcLoanStatus"] as string,
                parameters["avcLoanSubStatusCodes"] as string,
                parameters["avcContactFirstName"] as string,
                parameters["avcContactLastName"] as string,
                parameters["avcContactPhoneNumber"] as string,
                parameters["avcContactTypeSKeys"] as string,
                parameters["avcPropertyAddress"] as string,
                parameters["avcPropertyCity"] as string,
                parameters["avcPropertyStateCodes"] as string,
                parameters["avcPropertyZipCode"] as string,
                parameters["avcLoanServicerSKeys"] as string,
                parameters["avcInvestorSKeys"] as string,
                parameters["avcLoanPoolSKeys"] as string,
                parameters["avcProductTypeSKeys"] as string,
                parameters["avcPaymentPlanTypes"] as string,
                parameters["avcArmTypes"] as string,
                parameters["avcRateIndexTypeSKeys"] as string,
                parameters["avcLoanManagerId"] as string,
                parameters["adtmBoardedDateFrom"] as DateTime?,
                parameters["adtmBoardedDateTo"] as DateTime?,
                parameters["avcBoardingType"] as string,
                parameters["avcCreditType"] as string,
                parameters["avcIncludeAlerts"] as string,
                parameters["avcExcludeAlerts"] as string,
                parameters["avcIncludeDocs"] as string,
                parameters["avcExcludeDocs"] as string,
                parameters["aiPageNumber"] as int?,
                parameters["aiNumberOfRecords"] as int?,
                parameters["avcSortColumn"] as string,
                parameters["avcSortOrder"] as string);
        }

        public usp_GetResultsLoanQCSearch_Result GetEntityByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<usp_GetResultsLoanQCSearch_Result> FindBy(Expression<Func<usp_GetResultsLoanQCSearch_Result, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(usp_GetResultsLoanQCSearch_Result entity, params object[] ids)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
