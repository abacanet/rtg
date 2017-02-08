using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Data.Repositories
{
    public class LoanMasterRepository : IRepositoryAsync<app_loan_master>
    {
        private readonly ReverseQuestEntities _reverseQuestEntities;
        private bool _disposed;

        public LoanMasterRepository(ReverseQuestEntities reverseQuestEntities)
        {
            _reverseQuestEntities = reverseQuestEntities;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _reverseQuestEntities.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<app_loan_master> GetAsync(params object[] ids)
        {
            return await _reverseQuestEntities.app_loan_master.FindAsync(ids);
        }

        public Task<app_loan_master> AddAsync(app_loan_master entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(app_loan_master entity, params object[] ids)
        {
            if (Convert.ToInt32(ids[0]) != entity.loan_skey)
                throw new ArgumentException("The Id passed on the route does not match the Id on the Entity.");

            _reverseQuestEntities.Entry(entity).State = EntityState.Modified;

            try
            {
                return await _reverseQuestEntities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(ids))
                {
                    throw new ArgumentException("Entity does not exists in this Context.");
                }
                throw;
            }
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        private bool EntityExists(params object[] ids)
        {
            var tmp0 = Convert.ToInt32(ids[0]);

            return _reverseQuestEntities.app_loan_master.Count(e => e.loan_skey == tmp0) > 0;
        }
    }
}
