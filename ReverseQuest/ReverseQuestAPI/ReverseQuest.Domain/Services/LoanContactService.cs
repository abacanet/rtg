using System.Collections.Generic;
using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanContactService : IServiceAddEntity<LoanContactDetailsDTO, int>,
        IServiceGetEntityListBySkey<LoanContactDetailsDTO, usp_GetDetailsLoanContact_Result>,
        IServiceUpdateEntityBySkey<LoanContactDetailsDTO, int>
    {
        public LoanContactDetailsDTO AddEntity(IRepositoryForPrimitiveTypes<int> repository, LoanContactDetailsDTO entity)
        {
            repository.ExecuteFunctionBasedOnParameters(entity.MapToDictionary());
            return entity;
        }

        public IEnumerable<LoanContactDetailsDTO> GetListBySkey(IRepository<usp_GetDetailsLoanContact_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey);
            return 
                result?.Select(
                    loanContact => new LoanContactDetailsDTO().MapFromEntity(loanContact)).ToList();
        }

        public int UpdateEntityBySkey(IRepositoryForPrimitiveTypes<int> repository, LoanContactDetailsDTO entity, int skey)
        {
            return repository.ExecuteFunctionBasedOnParameters(entity.MapToDictionary());
        }
    }
}
