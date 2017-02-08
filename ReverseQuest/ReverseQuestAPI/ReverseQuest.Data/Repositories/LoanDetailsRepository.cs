using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Data.Repositories
{
    public class LoanDetailsRepository : IRepository<usp_GetDetailsLoanDetails_Result>
    {
        private readonly ReverseQuestEntities _reverseQuestEntities;
        private bool _disposed;

        public LoanDetailsRepository(ReverseQuestEntities reverseQuestEntities)
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

        public IQueryable<usp_GetDetailsLoanDetails_Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public ObjectResult<usp_GetDetailsLoanDetails_Result> ExecuteFunctionGet(params object[] ids)
        {
            var loanSkey = (int) ids[0];
            return _reverseQuestEntities.usp_GetDetailsLoanDetails(loanSkey);
        }

        public ObjectResult<usp_GetDetailsLoanDetails_Result> GetCollectionByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public usp_GetDetailsLoanDetails_Result GetEntityByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<usp_GetDetailsLoanDetails_Result> FindBy(Expression<Func<usp_GetDetailsLoanDetails_Result, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(usp_GetDetailsLoanDetails_Result entity, params object[] ids)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
