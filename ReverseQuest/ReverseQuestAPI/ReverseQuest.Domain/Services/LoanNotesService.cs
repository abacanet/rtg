using System.Collections.Generic;
using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanNotesService : IServiceGetEntityListByParameter<LoanNotesSearchDTO, usp_GetResultsLoanNoteSearch_Result>,
        IServiceAddEntity<LoanNotesDTO, int>,
        IServiceGetEntityListBySkey<LoanNotesDTO, usp_GetDetailsLoanNotes_Result>,
        IServiceUpdateEntityBySkey<LoanNotesDTO, int>
    {
        public IEnumerable<LoanNotesSearchDTO> GetEntityListByParameter(IRepository<usp_GetResultsLoanNoteSearch_Result> repository, IDictionary<string, object> parameters)
        {
            var resultList = repository.GetCollectionByExecutingFunctionBasedOnParameters(parameters);

            return
                resultList?.Select(
                        result => new LoanNotesSearchDTO().MapFromEntity(result))
                    .ToList();
        }

        public LoanNotesDTO AddEntity(IRepositoryForPrimitiveTypes<int> repository, LoanNotesDTO entity)
        {
            repository.ExecuteFunctionBasedOnParameters(entity.MapToDictionary());
            return entity;
        }

        public IEnumerable<LoanNotesDTO> GetListBySkey(IRepository<usp_GetDetailsLoanNotes_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey);
            return
                result?.Select(
                    loanNotesDTO => new LoanNotesDTO().MapFromEntity(loanNotesDTO)).ToList();
        }

        public int UpdateEntityBySkey(IRepositoryForPrimitiveTypes<int> repository, LoanNotesDTO entity, int skey)
        {
            return repository.ExecuteFunctionBasedOnParameters(entity.MapToDictionary());
        }
    }
}
