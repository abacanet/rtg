using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace ReverseQuest.Data.Repositories.Interface
{
    public interface IRepository<T> : IBaseRepository, IDisposable
    {
        IQueryable<T> GetAll();
        ObjectResult<T> ExecuteFunctionGet(params object[] ids);
        ObjectResult<T> GetCollectionByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters);
        T GetEntityByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters);
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        int Update(T entity, params object[] ids);
        int SaveChanges();
    }
}
