using System.Linq;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;
using ReverseQuest.Domain.DataTransformationObjects;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services.Interfaces.Sync;

namespace ReverseQuest.Domain.Services
{
    public class LoanDetailsService : IServiceGetEntityBySkey<LoanDetailsDTO, usp_GetDetailsLoanDetails_Result>
    {
        public LoanDetailsDTO GetEntityBySkey(IRepository<usp_GetDetailsLoanDetails_Result> repository, int skey)
        {
            var result = repository.ExecuteFunctionGet(skey).FirstOrDefault();

            if (result == null) return null;

            return new LoanDetailsDTO
            {
                LoanMasterDTO = new LoanMasterDTO().MapFromEntity(result),
                LoanServicerDTO = new LoanServicerDTO().MapFromEntity(result),
                LoanSubStatusDTO = new LoanSubStatusDTO().MapFromEntity(result),
                ReferenceProductTypeDTO = new ReferenceProductTypeDTO().MapFromEntity(result),
                PaymentPlanTypeDTO = new PaymentPlanTypeDTO().MapFromEntity(result),
                PaymentDTO = new PaymentDTO().MapFromEntity(result),
                ArmTypeDTO = new ArmTypeDTO().MapFromEntity(result),
                RateIndexTypeDTO = new RateIndexTypeDTO().MapFromEntity(result),
                LoanRatesDTO = new LoanRatesDTO().MapFromEntity(result),
                RffGroupDTO = new RffGroupDTO().MapFromEntity(result),
                CountyClerkDTO = new CountyClerkDTO().MapFromEntity(result)
            };
        }
    }
}
