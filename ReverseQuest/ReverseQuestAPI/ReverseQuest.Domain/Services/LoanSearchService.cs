using System.Collections.Generic;
using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanSearchService : IServiceGetEntityListByParameter<LoanSearchDTO, usp_GetResultsLoanSearch_Result>
    {
        public IEnumerable<LoanSearchDTO> GetEntityListByParameter(IRepository<usp_GetResultsLoanSearch_Result> repository, IDictionary<string, object> parameters)
        {
            var result = repository.GetCollectionByExecutingFunctionBasedOnParameters(parameters);

            return
                result?.Select(
                        uspGetResultsLoanSearchResult => new LoanSearchDTO().MapFromEntity(uspGetResultsLoanSearchResult))
                    .ToList();
        }
    }
}
