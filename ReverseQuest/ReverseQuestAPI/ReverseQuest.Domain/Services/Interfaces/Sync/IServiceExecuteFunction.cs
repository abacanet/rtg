using System.Collections.Generic;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceExecuteFunction<out TEntity, TStruct> where TEntity : struct where TStruct : struct
    {
        TEntity ExecuteFunctionByParameters(IRepositoryForPrimitiveTypes<TStruct> repository,
            IDictionary<string, object> parameters);
    }
}
