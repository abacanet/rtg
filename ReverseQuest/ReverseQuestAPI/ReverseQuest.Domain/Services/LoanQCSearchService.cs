using System.Collections.Generic;
using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanQCSearchService : IServiceGetEntityListByParameter<LoanQCSearchDTO, usp_GetResultsLoanQCSearch_Result>
    {
        public IEnumerable<LoanQCSearchDTO> GetEntityListByParameter(IRepository<usp_GetResultsLoanQCSearch_Result> repository, IDictionary<string, object> parameters)
        {
            var result = repository.GetCollectionByExecutingFunctionBasedOnParameters(parameters);

            return
                result?.Select(
                        uspGetResultsLoanSearchResult => new LoanQCSearchDTO().MapFromEntity(uspGetResultsLoanSearchResult))
                    .ToList();
        }
    }
}
