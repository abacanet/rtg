using System.Collections.Generic;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class NextSystemKeyService : IServiceGetPrimitiveTypeByParameter<int>
    {
        public int GetPrimitiveTypeByParameter(IRepositoryForPrimitiveTypes<int> repository, IDictionary<string, object> parameters)
        {
            return repository.ExecuteFunctionBasedOnParameters(parameters);
        }
    }
}
