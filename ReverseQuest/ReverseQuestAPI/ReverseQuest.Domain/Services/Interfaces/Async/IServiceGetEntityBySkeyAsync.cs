using System.Threading.Tasks;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;

namespace ReverseQuest.Domain.Services.Interfaces.Async
{
    public interface IServiceGetEntityBySkeyAsync<TEntity, TDataType> where TEntity : BaseDTO where TDataType : class
    {
        Task<TEntity> GetEntityBySkeyAsync(IRepositoryAsync<TDataType> repository, int skey);
    }
}
