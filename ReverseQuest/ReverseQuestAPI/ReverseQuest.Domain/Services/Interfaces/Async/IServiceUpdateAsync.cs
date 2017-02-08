using System.Threading.Tasks;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;

namespace ReverseQuest.Domain.Services.Interfaces.Async
{
    public interface IServiceUpdateEntityBySkeyAsync<in TEntity, TDataType> where TEntity : BaseDTO where TDataType : class
    {
        Task<int> UpdateEntityBySkeyAsync(IRepositoryAsync<TDataType> repository, TEntity entity, int skey);
    }
}
