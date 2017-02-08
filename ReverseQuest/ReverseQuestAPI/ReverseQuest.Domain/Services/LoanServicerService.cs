using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanServicerService : IServiceGetEntityBySkey<LoanServicerDTO, usp_GetDetailsLoanDetails_Result>
    {
        public LoanServicerDTO GetEntityBySkey(IRepository<usp_GetDetailsLoanDetails_Result> repository, int skey)
        {
            return new LoanServicerDTO();
        }
    }
}
