using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories.Interface;

namespace ReverseQuest.Data.Repositories
{
    public class LoanContactInsertRepository : IRepositoryForPrimitiveTypes<int>
    {
        private readonly ReverseQuestEntities _reverseQuestEntities;
        private bool _disposed;

        public LoanContactInsertRepository(ReverseQuestEntities reverseQuestEntities)
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
            return _reverseQuestEntities.usp_InsertContact(
                parameters["ai_LoanSkey"] as int?,
                parameters["ai_ContactTypeSkey"] as int?,
                parameters["avc_OtherContactTypeDescription"] as string,
                parameters["avc_FirstName"] as string,
                parameters["avc_MiddleName"] as string,
                parameters["avc_LastName"] as string,
                parameters["avc_SSN"] as string,
                parameters["ac_Gender"] as string,
                parameters["adtm_BirthDate"] as DateTime?,
                parameters["adtm_DeathDate"] as DateTime?,
                parameters["avc_Address1"] as string,
                parameters["avc_Address2"] as string,
                parameters["avc_City"] as string,
                parameters["avc_StateCode"] as string,
                parameters["avc_ZipCode"] as string,
                parameters["an_HomePhoneNumber"] as decimal?,
                parameters["an_WorkPhoneNumber"] as decimal?,
                parameters["an_CellPhoneNumber"] as decimal?,
                parameters["an_FaxNumber"] as decimal?,
                parameters["avc_Email"] as string,
                parameters["avc_MailFirstName"] as string,
                parameters["avc_MailMiddleName"] as string,
                parameters["avc_MailLastName"] as string,
                parameters["avc_MailAddress1"] as string,
                parameters["avc_MailAddress2"] as string,
                parameters["avc_MailCity"] as string,
                parameters["avc_MailStateCode"] as string,
                parameters["avc_MailZipCode"] as string,
                parameters["ai_MaritalStatusSkey"] as int?,
                parameters["ai_LanguagePreferenceSkey"] as int?,
                parameters["avc_CompanyName"] as string,
                parameters["avc_MailCompanyName"] as string,
                parameters["ai_ResidencyStatusSkey"] as int?,
                parameters["ab_EmergencyContactFlag"] as bool?,
                parameters["ab_AuthorizedContactFlag"] as bool?,
                parameters["ab_ENBSIndicator"] as bool?,
                parameters["ai_ParentContactSkey"] as int?,
                parameters["ab_LegalOwnerFlag"] as bool?,
                parameters["ab_RightToOccupyFlag"] as bool?,
                parameters["ab_DivorcedFlag"] as bool?,
                parameters["ac_MortgageeOptionalElection"] as string,
                parameters["ab_EmailPreferredFlag"] as bool?,
                parameters["ai_SignatureImageTypeSkey"] as int?,
                parameters["ai_StatusSkey"] as int?);
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
