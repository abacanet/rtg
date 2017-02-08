using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceUpdateEntityBySkey<in TEntity, TStruct> where TEntity : BaseDTO where TStruct : struct
    {
        TStruct UpdateEntityBySkey(IRepositoryForPrimitiveTypes<TStruct> repository, TEntity entity, int skey);
    }
}
