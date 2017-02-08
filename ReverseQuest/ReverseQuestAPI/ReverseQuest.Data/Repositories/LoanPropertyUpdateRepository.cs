using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Data.Repositories
{
    public class LoanPropertyUpdateRepository : IRepositoryForPrimitiveTypes<int>
    {
        private readonly ReverseQuestEntities _reverseQuestEntities;
        private bool _disposed;

        public LoanPropertyUpdateRepository(ReverseQuestEntities reverseQuestEntities)
        {
            _reverseQuestEntities = reverseQuestEntities;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _reverseQuestEntities.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<int> GetAll()
        {
            throw new NotImplementedException();
        }

        public int ExecuteFunction(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<int> ExecuteFunctionGet(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<int> GetCollectionByExecutingFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteFunctionBasedOnParameters(IDictionary<string, object> parameters)
        {
            return _reverseQuestEntities.usp_UpdateProperty(
                parameters["ai_LoanSkey"] as int?,
                parameters["avc_Address1"] as string,
                parameters["avc_Address2"] as string,
                parameters["avc_City"] as string,
                parameters["avc_StateCode"] as string,
                parameters["avc_ZipCode"] as string,
                parameters["avc_LegalDescription"] as string,
                parameters["ab_OwnerOccupiedFlag"] as bool?,
                parameters["adtm_OccupancyDate"] as DateTime?,
                parameters["ai_CountyClerkSkey"] as int?,
                parameters["ai_PropertyTypeSkey"] as int?,
                parameters["ai_NumberOfUnits"] as int?,
                parameters["ai_FloodZoneSkey"] as int?,
                parameters["ab_RequiresFloodInsuranceFlag"] as bool?,
                parameters["avc_FloodCertificateNumber"] as string,
                parameters["ai_FloodInsuranceCompanySkey"] as int?,
                parameters["ab_LifeOfLoanPolicyFlag"] as bool?,
                parameters["adtm_VacancyDate"] as DateTime?);
        }

        public IQueryable<int> FindBy(Expression<Func<int, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
