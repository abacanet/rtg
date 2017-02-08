using System.Collections.Generic;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class ProcessLoanBoardingFileService : IServiceExecuteFunction<int, int>
    {
        public int ExecuteFunctionByParameters(IRepositoryForPrimitiveTypes<int> repository, IDictionary<string, object> parameters)
        {
            return repository.ExecuteFunctionBasedOnParameters(parameters);
        }
    }
}
