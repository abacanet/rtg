using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceAddEntity<TEntity, TStruct> where TEntity : BaseDTO where TStruct : struct
    {
        TEntity AddEntity(IRepositoryForPrimitiveTypes<TStruct> repository, TEntity entity);
    }
}
