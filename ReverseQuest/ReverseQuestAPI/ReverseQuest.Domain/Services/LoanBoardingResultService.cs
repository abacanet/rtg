using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanBoardingResultService : IServiceGetEntityBySkey<LoanBoardingResultDTO, usp_GetListLoanBoardingResult_Result>
    {
        public LoanBoardingResultDTO GetEntityBySkey(IRepository<usp_GetListLoanBoardingResult_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey).FirstOrDefault();

            return result == null ? null : new LoanBoardingResultDTO().MapFromEntity(result);
        }
    }
}
