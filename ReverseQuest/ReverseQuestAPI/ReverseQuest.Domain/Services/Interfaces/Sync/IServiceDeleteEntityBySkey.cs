using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceDeleteEntityBySkey<TStruct> where TStruct : struct
    {
        TStruct DeleteEntityBySkey(IRepositoryForPrimitiveTypes<TStruct> repository, int skey);
    }
}
