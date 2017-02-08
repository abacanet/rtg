using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanPropertyService : IServiceGetEntityBySkey<LoanPropertyDTO, usp_GetDetailsLoanProperty_Result>,
        IServiceUpdateEntityBySkey<LoanPropertyDTO, int>
    {
        public LoanPropertyDTO GetEntityBySkey(IRepository<usp_GetDetailsLoanProperty_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey).FirstOrDefault();
            return result == null ? null : new LoanPropertyDTO().FromEntityModel(result);
        }

        public int UpdateEntityBySkey(IRepositoryForPrimitiveTypes<int> repository, LoanPropertyDTO entity, int skey)
        {
            return repository.ExecuteFunctionBasedOnParameters(entity.ToParametersDictionary());
        }
    }
}
