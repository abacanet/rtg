using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanBalanceService : IServiceGetEntityBySkey<LoanBalanceDTO, usp_GetDetailsLoanBalances_Result>
    {
        public LoanBalanceDTO GetEntityBySkey(IRepository<usp_GetDetailsLoanBalances_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey).FirstOrDefault();

            if (result == null) return null;

            var loanBalanceDTO = new LoanBalanceDTO().MapFromEntity(result);
            loanBalanceDTO.LoanSkey = skey;
            loanBalanceDTO.Idl.LoanSkey = skey;

            return loanBalanceDTO;
        }
    }
}
