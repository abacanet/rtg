using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Data.Repositories
{
    public class LoanNotesUpdateRepository : IRepositoryForPrimitiveTypes<int>
    {
        private readonly ReverseQuestEntities _reverseQuestEntities;
        private bool _disposed;

        public LoanNotesUpdateRepository(ReverseQuestEntities reverseQuestEntities)
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

        public IQueryable<int> GetAll()
        {
            throw new NotImplementedException();
        }

        public int ExecuteFunction(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<int> ExecuteFunctionGet(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<int> GetCollectionByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            return _reverseQuestEntities.usp_UpdateNote(
                parameters["ai_NoteSkey"] as int?,
                parameters["ai_ContactSkey"] as int?,
                parameters["ai_NoteTypeSkey"] as int?,
                parameters["ab_HighImportanceFlag"] as bool?,
                parameters["avc_NoteText"] as string);
        }

        public IQueryable<int> FindBy(Expression<Func<int, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
