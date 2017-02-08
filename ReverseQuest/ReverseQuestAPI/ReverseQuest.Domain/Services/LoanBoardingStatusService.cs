using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanBoardingStatusService : IServiceGetEntityBySkey<LoanBoardingStatusDTO, usp_GetLoanBoardingStatus_Result>
    {
        public LoanBoardingStatusDTO GetEntityBySkey(IRepository<usp_GetLoanBoardingStatus_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey).FirstOrDefault();

            return result == null ? null : new LoanBoardingStatusDTO().MapFromEntity(result);
        }
    }
}
