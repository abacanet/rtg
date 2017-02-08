using System.Collections.Generic;
using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanPropertyValueService : IServiceUpdateEntityBySkey<LoanPropertyValueDTO, int>,
        IServiceAddEntity<LoanPropertyValueDTO, int>,
        IServiceDeleteEntityBySkey<int>,
        IServiceGetEntityListBySkey<LoanPropertyValueDTO, usp_GetDetailsLoanPropertyValues_Result>
    {
        public int UpdateEntityBySkey(IRepositoryForPrimitiveTypes<int> repository, LoanPropertyValueDTO entity, int skey)
        {
            return repository.ExecuteFunctionBasedOnParameters(entity.MapToDictionary());
        }

        public LoanPropertyValueDTO AddEntity(IRepositoryForPrimitiveTypes<int> repository, LoanPropertyValueDTO entity)
        {
            repository.ExecuteFunctionBasedOnParameters(entity.MapToDictionary());
            return entity;
        }

        public int DeleteEntityBySkey(IRepositoryForPrimitiveTypes<int> repository, int skey)
        {
            return repository.ExecuteFunction(skey);
        }

        public IEnumerable<LoanPropertyValueDTO> GetListBySkey(IRepository<usp_GetDetailsLoanPropertyValues_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey);

            return
                result.Select(
                    uspGetDetailsLoanPropertyResult =>
                            new LoanPropertyValueDTO().MapFromEntity(uspGetDetailsLoanPropertyResult)).ToList();
        }
    }
}
