using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanRatesService : IServiceGetEntityBySkey<LoanRatesDTO, usp_GetDetailsLoanDetails_Result>
    {
        public LoanRatesDTO GetEntityBySkey(IRepository<usp_GetDetailsLoanDetails_Result> repository, int skey)
        {
            return new LoanRatesDTO();
        }
    }
}
