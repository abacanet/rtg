using System;
using System.Threading.Tasks;

namespace ReverseQuest.Data.Repositories.Interface
{
    public interface IRepositoryAsync<T> : IDisposable where T : class
    {
        Task<T> GetAsync(params object[] ids);
        Task<T> AddAsync(T entity);
        Task<int> DeleteAsync(params object[] ids);
        Task<int> UpdateAsync(T entity, params object[] ids);
        Task<int> SaveChangesAsync();

    }
}