using System.Collections.Generic;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class ServiceTest : IServiceGetEntityBySkey<LoanDetailsDTO, usp_GetDetailsLoanDetails_Result>,
        IServiceGetEntityListBySkey<LoanDetailsDTO, usp_GetDetailsLoanAlert_Result>,
        IServiceGetEntityListBySkey<LoanDetailsDTO, usp_GetDetailsLoanContact_Result>
    {
        public LoanDetailsDTO GetEntityBySkey(IRepository<usp_GetDetailsLoanDetails_Result> repository, int skey)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LoanDetailsDTO> GetListBySkey(IRepository<usp_GetDetailsLoanAlert_Result> repository, int skey)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LoanDetailsDTO> GetListBySkey(IRepository<usp_GetDetailsLoanContact_Result> repository, int skey)
        {
            throw new System.NotImplementedException();
        }
    }
}
