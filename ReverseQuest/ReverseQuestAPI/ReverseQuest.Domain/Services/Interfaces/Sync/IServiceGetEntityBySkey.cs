using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceGetEntityBySkey<out TEntity, TDataType> where TEntity : BaseDTO where TDataType : class
    {
        TEntity GetEntityBySkey(IRepository<TDataType> repository, int skey);
    }
}
