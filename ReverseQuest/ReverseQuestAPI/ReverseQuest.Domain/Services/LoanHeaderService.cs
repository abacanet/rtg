using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanHeaderService : IServiceGetEntityBySkey<LoanHeaderDTO, usp_GetStandardLoanHeaderInformation_Result>
    {
        public LoanHeaderDTO GetEntityBySkey(IRepository<usp_GetStandardLoanHeaderInformation_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey).FirstOrDefault();
            return result == null ? null : new LoanHeaderDTO().MapFromEntity(result);
        }
    }
}
