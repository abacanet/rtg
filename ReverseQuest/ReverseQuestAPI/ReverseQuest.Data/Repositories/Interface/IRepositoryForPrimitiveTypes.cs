using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace ReverseQuest.Data.Repositories.Interface
{
    public interface IRepositoryForPrimitiveTypes<T> : IDisposable where T : struct
    {
        IQueryable<T> GetAll();
        T ExecuteFunction(params object[] ids);
        ObjectResult<T> ExecuteFunctionGet(params object[] ids);
        ObjectResult<T> GetCollectionByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters);
        T ExecuteFunctionBasedOnParameters(IDictionary<string, object> parameters);
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        int SaveChanges();
    }
}
