using System.Collections.Generic;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceGetEntityListBySkey<out TEntity, TDataType> where TEntity : BaseDTO where TDataType : class
    {
        IEnumerable<TEntity> GetListBySkey(IRepository<TDataType> repository, int skey);
    }
}
