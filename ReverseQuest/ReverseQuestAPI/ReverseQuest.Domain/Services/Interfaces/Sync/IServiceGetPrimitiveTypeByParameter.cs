using System.Collections.Generic;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Domain.Services.Interfaces.Sync
{
    public interface IServiceGetPrimitiveTypeByParameter<TDataType> where TDataType : struct
    {
        TDataType GetPrimitiveTypeByParameter(IRepositoryForPrimitiveTypes<TDataType> repository, IDictionary<string, object> parameters);
    }
}
