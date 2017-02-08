using System.Collections.Generic;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceGetEntityListByParameter<out TEntity, TDataType> where TEntity : BaseDTO where TDataType : class
    {
        IEnumerable<TEntity> GetEntityListByParameter(IRepository<TDataType> repository, IDictionary<string, object> parameters);
    }
}
