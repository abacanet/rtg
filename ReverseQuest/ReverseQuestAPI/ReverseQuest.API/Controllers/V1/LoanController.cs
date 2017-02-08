using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using ReverseQuest.Common.Routing;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services;

namespace ReverseQuest.API.Controllers.V1
{
    [ApiVersion1RoutePrefix("Loan")]
    public class LoanController : ApiController
    {
        //GET api/{apiVersion}/Loan/Search?aiPageNumber=1&aiNumberOfRecords=100
        //the other arguments are optional
        //GET api/{apiVersion}/Loan/Search?aiPageNumber={aiPageNumber}&aiNumberOfRecords={aiNumberOfRecords}&aiLoanSKey={aiLoanSKey}&avcOriginalLoanNumber={avcOriginalLoanNumber}&avcFhaCaseNumber={avcFhaCaseNumber}&avcInvestorLoanNumber={avcInvestorLoanNumber}&avcPriorServicerLoanNumber={avcPriorServicerLoanNumber}&avcLoanStatus={avcLoanStatus}&avcLoanSubStatusCodes={avcLoanSubStatusCodes}&avcContactFirstName={avcContactFirstName}&avcContactLastName={avcContactLastName}&avcContactPhoneNumber={avcContactPhoneNumber}&avcContactTypeSKeys={avcContactTypeSKeys}&avcPropertyAddress={avcPropertyAddress}&avcPropertyCity={avcPropertyCity}&avcPropertyStateCodes={avcPropertyStateCodes}&avcPropertyZipCode={avcPropertyZipCode}&avcLoanServicerSKeys={avcLoanServicerSKeys}&avcInvestorSKeys={avcInvestorSKeys}&avcLoanPoolSKeys={avcLoanPoolSKeys}&avcProductTypeSKeys={avcProductTypeSKeys}&avcPaymentPlanTypes={avcPaymentPlanTypes}&avcArmTypes={avcArmTypes}&avcRateIndexTypeSKeys={avcRateIndexTypeSKeys}&avcLoanManagerId={avcLoanManagerId}&adtmBoardedDateFrom={adtmBoardedDateFrom}&adtmBoardedDateTo={adtmBoardedDateTo}&avcBoardingType={avcBoardingType}&avcCreditType={avcCreditType}&avcIncludeAlerts={avcIncludeAlerts}&avcExcludeAlerts={avcExcludeAlerts}&avcIncludeDocs={avcIncludeDocs}&avcExcludeDocs={avcExcludeDocs}&avcSortColumn={avcSortColumn}&avcSortOrder={avcSortOrder}
        [HttpGet]
        [Route("Search", Name = "GetLoanSearchV1")]
        [ResponseType(typeof(IEnumerable<LoanDetailsDTO>))]
        public IHttpActionResult LoanSearch(
            [FromUri] int aiPageNumber,
            [FromUri] int aiNumberOfRecords,
            [FromUri] int? aiLoanSKey = null,
            [FromUri] string avcOriginalLoanNumber = null,
            [FromUri] string avcFhaCaseNumber = null,
            [FromUri] string avcInvestorLoanNumber = null,
            [FromUri] string avcPriorServicerLoanNumber = null,
            [FromUri] string avcLoanStatus = null,
            [FromUri] string avcLoanSubStatusCodes = null,
            [FromUri] string avcContactFirstName = null,
            [FromUri] string avcContactLastName = null,
            [FromUri] string avcContactPhoneNumber = null,
            [FromUri] string avcContactTypeSKeys = null,
            [FromUri] string avcPropertyAddress = null,
            [FromUri] string avcPropertyCity = null,
            [FromUri] string avcPropertyStateCodes = null,
            [FromUri] string avcPropertyZipCode = null,
            [FromUri] string avcLoanServicerSKeys = null,
            [FromUri] string avcInvestorSKeys = null,
            [FromUri] string avcLoanPoolSKeys = null,
            [FromUri] string avcProductTypeSKeys = null,
            [FromUri] string avcPaymentPlanTypes = null,
            [FromUri] string avcArmTypes = null,
            [FromUri] string avcRateIndexTypeSKeys = null,
            [FromUri] string avcLoanManagerId = null,
            [FromUri] DateTime? adtmBoardedDateFrom = null,
            [FromUri] DateTime? adtmBoardedDateTo = null,
            [FromUri] string avcBoardingType = null,
            [FromUri] string avcCreditType = null,
            [FromUri] string avcIncludeAlerts = null,
            [FromUri] string avcExcludeAlerts = null,
            [FromUri] string avcIncludeDocs = null,
            [FromUri] string avcExcludeDocs = null,
            [FromUri] string avcSortColumn = null,
            [FromUri] string avcSortOrder = null)
        {
            var param = new Dictionary<string, object>
            {
                {"aiLoanSKey", aiLoanSKey},
                {"avcOriginalLoanNumber", avcOriginalLoanNumber},
                {"avcFhaCaseNumber", avcFhaCaseNumber},
                {"avcInvestorLoanNumber", avcInvestorLoanNumber},
                {"avcPriorServicerLoanNumber", avcPriorServicerLoanNumber},
                {"avcLoanStatus", avcLoanStatus},
                {"avcLoanSubStatusCodes", avcLoanSubStatusCodes},
                {"avcContactFirstName", avcContactFirstName},
                {"avcContactLastName", avcContactLastName},
                {"avcContactPhoneNumber", avcContactPhoneNumber},
                {"avcContactTypeSKeys", avcContactTypeSKeys},
                {"avcPropertyAddress", avcPropertyAddress},
                {"avcPropertyCity", avcPropertyCity},
                {"avcPropertyStateCodes", avcPropertyStateCodes},
                {"avcPropertyZipCode", avcPropertyZipCode},
                {"avcLoanServicerSKeys", avcLoanServicerSKeys},
                {"avcInvestorSKeys", avcInvestorSKeys},
                {"avcLoanPoolSKeys", avcLoanPoolSKeys},
                {"avcProductTypeSKeys", avcProductTypeSKeys},
                {"avcPaymentPlanTypes", avcPaymentPlanTypes},
                {"avcArmTypes", avcArmTypes},
                {"avcRateIndexTypeSKeys", avcRateIndexTypeSKeys},
                {"avcLoanManagerId", avcLoanManagerId},
                {"adtmBoardedDateFrom", adtmBoardedDateFrom},
                {"adtmBoardedDateTo", adtmBoardedDateTo},
                {"avcBoardingType", avcBoardingType},
                {"avcCreditType", avcCreditType},
                {"avcIncludeAlerts", avcIncludeAlerts},
                {"avcExcludeAlerts", avcExcludeAlerts},
                {"avcIncludeDocs", avcIncludeDocs},
                {"avcExcludeDocs", avcExcludeDocs},
                {"aiPageNumber", aiPageNumber},
                {"aiNumberOfRecords", aiNumberOfRecords},
                {"avcSortColumn", avcSortColumn},
                {"avcSortOrder", avcSortOrder}
            };
            var loanSearchService = new LoanSearchService();
            var repository = new LoanSearchRepository(new ReverseQuestEntities());
            var result = loanSearchService.GetEntityListByParameter(repository, param);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/Loan/NotesSearch?aiPageNumber=1&aiNumberOfRecords=100
        //GET api/{apiVersion}/Loan/NotesSearch?aiPageNumber=1&aiNumberOfRecords=100&aiLoanSKey={aiLoanSKey}&avcOriginalLoanNumber={avcOriginalLoanNumber}&avcLoanStatus={avcLoanStatus}&avcLoanSubStatusCodes={avcLoanSubStatusCodes}&avcLoanServicerSKeys={avcLoanServicerSKeys}&avcInvestorSKeys={avcInvestorSKeys}&avcLoanPoolSKeys={avcLoanPoolSKeys}&avcProductTypeSKeys={avcProductTypeSKeys}&avcHighImportanceFlag={avcHighImportanceFlag}&avcNoteText={avcNoteText}&adtmCreatedDateFrom={adtmCreatedDateFrom}&adtmCreatedDateTo={adtmCreatedDateTo}&avcCreatedBy={avcCreatedBy}&avcNoteTypeSkeys={avcNoteTypeSkeys}&avcNoteTypeCategorySkeys={avcNoteTypeCategorySkeys}&avcSortColumn={avcSortColumn}&avcSortOrder={avcSortOrder}
        //the other arguments are optional
        [HttpGet]
        [Route("NotesSearch", Name = "GetLoanNotesSearchV1")]
        [ResponseType(typeof(IEnumerable<LoanDetailsDTO>))]
        public IHttpActionResult LoanNoteSearch(
            [FromUri] int aiPageNumber,
            [FromUri] int aiNumberOfRecords,
            [FromUri] int? aiLoanSKey = null,
            [FromUri] string avcOriginalLoanNumber = null,
            [FromUri] string avcLoanStatus = null,
            [FromUri] string avcLoanSubStatusCodes = null,
            [FromUri] string avcLoanServicerSKeys = null,
            [FromUri] string avcInvestorSKeys = null,
            [FromUri] string avcLoanPoolSKeys = null,
            [FromUri] string avcProductTypeSKeys = null,
            [FromUri] string avcHighImportanceFlag = null,
            [FromUri] string avcNoteText = null,
            [FromUri] DateTime? adtmCreatedDateFrom = null,
            [FromUri] DateTime? adtmCreatedDateTo = null,
            [FromUri] string avcCreatedBy = null,
            [FromUri] string avcNoteTypeSkeys = null,
            [FromUri] string avcNoteTypeCategorySkeys = null,
            [FromUri] string avcSortColumn = null,
            [FromUri] string avcSortOrder = null)
        {
            var param = new Dictionary<string, object>
            {
                {"aiLoanSKey", aiLoanSKey},
                {"avcOriginalLoanNumber", avcOriginalLoanNumber},
                {"avcLoanStatus", avcLoanStatus},
                {"avcLoanSubStatusCodes", avcLoanSubStatusCodes},
                {"avcLoanServicerSKeys", avcLoanServicerSKeys},
                {"avcInvestorSKeys", avcInvestorSKeys},
                {"avcLoanPoolSKeys", avcLoanPoolSKeys},
                {"avcProductTypeSKeys", avcProductTypeSKeys},
                {"avcHighImportanceFlag", avcHighImportanceFlag},
                {"avcNoteText", avcNoteText},
                {"adtmCreatedDateFrom", adtmCreatedDateFrom},
                {"adtmCreatedDateTo", adtmCreatedDateTo},
                {"avcCreatedBy", avcCreatedBy},
                {"avcNoteTypeSkeys", avcNoteTypeSkeys},
                {"avcNoteTypeCategorySkeys", avcNoteTypeCategorySkeys},
                {"aiPageNumber", aiPageNumber},
                {"aiNumberOfRecords", aiNumberOfRecords},
                {"avcSortColumn", avcSortColumn},
                {"avcSortOrder", avcSortOrder}
            };

            var service = new LoanNotesService();
            var repository = new LoanNotesSearchRepository(new ReverseQuestEntities());
            var result = service.GetEntityListByParameter(repository, param);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/Loan/QCSearch?aiPageNumber=1&aiNumberOfRecords=100
        //the other arguments are optional
        //GET api/{apiVersion}/Loan/QCSearch?aiPageNumber={aiPageNumber}&aiNumberOfRecords={aiNumberOfRecords}&aiLoanSKey={aiLoanSKey}&avcOriginalLoanNumber={avcOriginalLoanNumber}&avcFhaCaseNumber={avcFhaCaseNumber}&avcInvestorLoanNumber={avcInvestorLoanNumber}&avcPriorServicerLoanNumber={avcPriorServicerLoanNumber}&avcLoanStatus={avcLoanStatus}&avcLoanSubStatusCodes={avcLoanSubStatusCodes}&avcContactFirstName={avcContactFirstName}&avcContactLastName={avcContactLastName}&avcContactPhoneNumber={avcContactPhoneNumber}&avcContactTypeSKeys={avcContactTypeSKeys}&avcPropertyAddress={avcPropertyAddress}&avcPropertyCity={avcPropertyCity}&avcPropertyStateCodes={avcPropertyStateCodes}&avcPropertyZipCode={avcPropertyZipCode}&avcLoanServicerSKeys={avcLoanServicerSKeys}&avcInvestorSKeys={avcInvestorSKeys}&avcLoanPoolSKeys={avcLoanPoolSKeys}&avcProductTypeSKeys={avcProductTypeSKeys}&avcPaymentPlanTypes={avcPaymentPlanTypes}&avcArmTypes={avcArmTypes}&avcRateIndexTypeSKeys={avcRateIndexTypeSKeys}&avcLoanManagerId={avcLoanManagerId}&adtmBoardedDateFrom={adtmBoardedDateFrom}&adtmBoardedDateTo={adtmBoardedDateTo}&avcBoardingType={avcBoardingType}&avcCreditType={avcCreditType}&avcIncludeAlerts={avcIncludeAlerts}&avcExcludeAlerts={avcExcludeAlerts}&avcIncludeDocs={avcIncludeDocs}&avcExcludeDocs={avcExcludeDocs}&avcSortColumn={avcSortColumn}&avcSortOrder={avcSortOrder}
        [HttpGet]
        [Route("QCSearch", Name = "GetLoanQCSearchV1")]
        [ResponseType(typeof(IEnumerable<LoanQCSearchDTO>))]
        public IHttpActionResult LoanQCSearch(
            [FromUri] int aiPageNumber,
            [FromUri] int aiNumberOfRecords,
            [FromUri] int? aiLoanSKey = null,
            [FromUri] string avcOriginalLoanNumber = null,
            [FromUri] string avcFhaCaseNumber = null,
            [FromUri] string avcInvestorLoanNumber = null,
            [FromUri] string avcPriorServicerLoanNumber = null,
            [FromUri] string avcLoanStatus = null,
            [FromUri] string avcLoanSubStatusCodes = null,
            [FromUri] string avcContactFirstName = null,
            [FromUri] string avcContactLastName = null,
            [FromUri] string avcContactPhoneNumber = null,
            [FromUri] string avcContactTypeSKeys = null,
            [FromUri] string avcPropertyAddress = null,
            [FromUri] string avcPropertyCity = null,
            [FromUri] string avcPropertyStateCodes = null,
            [FromUri] string avcPropertyZipCode = null,
            [FromUri] string avcLoanServicerSKeys = null,
            [FromUri] string avcInvestorSKeys = null,
            [FromUri] string avcLoanPoolSKeys = null,
            [FromUri] string avcProductTypeSKeys = null,
            [FromUri] string avcPaymentPlanTypes = null,
            [FromUri] string avcArmTypes = null,
            [FromUri] string avcRateIndexTypeSKeys = null,
            [FromUri] string avcLoanManagerId = null,
            [FromUri] DateTime? adtmBoardedDateFrom = null,
            [FromUri] DateTime? adtmBoardedDateTo = null,
            [FromUri] string avcBoardingType = null,
            [FromUri] string avcCreditType = null,
            [FromUri] string avcIncludeAlerts = null,
            [FromUri] string avcExcludeAlerts = null,
            [FromUri] string avcIncludeDocs = null,
            [FromUri] string avcExcludeDocs = null,
            [FromUri] string avcSortColumn = null,
            [FromUri] string avcSortOrder = null)
        {
            var param = new Dictionary<string, object>
            {
                {"aiLoanSKey", aiLoanSKey},
                {"avcOriginalLoanNumber", avcOriginalLoanNumber},
                {"avcFhaCaseNumber", avcFhaCaseNumber},
                {"avcInvestorLoanNumber", avcInvestorLoanNumber},
                {"avcPriorServicerLoanNumber", avcPriorServicerLoanNumber},
                {"avcLoanStatus", avcLoanStatus},
                {"avcLoanSubStatusCodes", avcLoanSubStatusCodes},
                {"avcContactFirstName", avcContactFirstName},
                {"avcContactLastName", avcContactLastName},
                {"avcContactPhoneNumber", avcContactPhoneNumber},
                {"avcContactTypeSKeys", avcContactTypeSKeys},
                {"avcPropertyAddress", avcPropertyAddress},
                {"avcPropertyCity", avcPropertyCity},
                {"avcPropertyStateCodes", avcPropertyStateCodes},
                {"avcPropertyZipCode", avcPropertyZipCode},
                {"avcLoanServicerSKeys", avcLoanServicerSKeys},
                {"avcInvestorSKeys", avcInvestorSKeys},
                {"avcLoanPoolSKeys", avcLoanPoolSKeys},
                {"avcProductTypeSKeys", avcProductTypeSKeys},
                {"avcPaymentPlanTypes", avcPaymentPlanTypes},
                {"avcArmTypes", avcArmTypes},
                {"avcRateIndexTypeSKeys", avcRateIndexTypeSKeys},
                {"avcLoanManagerId", avcLoanManagerId},
                {"adtmBoardedDateFrom", adtmBoardedDateFrom},
                {"adtmBoardedDateTo", adtmBoardedDateTo},
                {"avcBoardingType", avcBoardingType},
                {"avcCreditType", avcCreditType},
                {"avcIncludeAlerts", avcIncludeAlerts},
                {"avcExcludeAlerts", avcExcludeAlerts},
                {"avcIncludeDocs", avcIncludeDocs},
                {"avcExcludeDocs", avcExcludeDocs},
                {"aiPageNumber", aiPageNumber},
                {"aiNumberOfRecords", aiNumberOfRecords},
                {"avcSortColumn", avcSortColumn},
                {"avcSortOrder", avcSortOrder}
            };

            var loanSearchService = new LoanQCSearchService();
            var repository = new LoanQCSearchRepository(new ReverseQuestEntities());
            var result = loanSearchService.GetEntityListByParameter(repository, param);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/Loan/Header?skey=12345
        [HttpGet]
        [Route("Header", Name = "GetLoanHeaderV1")]
        [ResponseType(typeof(LoanHeaderDTO))]
        public IHttpActionResult GetLoanHeader([FromUri] int skey)
        {
            var service = new LoanHeaderService();
            var repository = new LoanHeaderRepository(new ReverseQuestEntities());
            var result = service.GetEntityBySkey(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //POST api/{apiVersion}/Loan/ProcessLoanBoardingFile?aiBatchSkey=123&aiLoanServicerSkey=456&aiInvestorSkey=789aiLoanPoolSkey=12&aiPropertyTypeCategorySkey=34&acBoardingType=test
        [HttpPost]
        [Route("ProcessLoanBoardingFile", Name = "ProcessLoanBoardingFileV1")]
        [ResponseType(typeof(void))]
        public IHttpActionResult ProcessLoanBoardingFile(
            [FromUri] int aiBatchSkey,
            [FromUri] int aiLoanServicerSkey,
            [FromUri] int aiInvestorSkey,
            [FromUri] int aiLoanPoolSkey,
            [FromUri] int aiPropertyTypeCategorySkey,
            [FromUri] string acBoardingType)
        {
            var param = new Dictionary<string, object>
            {
                {"aiBatchSkey", aiBatchSkey},
                {"aiLoanServicerSkey", aiLoanServicerSkey},
                {"aiInvestorSkey", aiInvestorSkey},
                {"aiLoanPoolSkey", aiLoanPoolSkey},
                {"aiPropertyTypeCategorySkey", aiPropertyTypeCategorySkey},
                {"acBoardingType", acBoardingType}
            };

            var service = new ProcessLoanBoardingFileService();
            var repository = new ProcessLoanBoardingFileRepository(new ReverseQuestEntities());
            service.ExecuteFunctionByParameters(repository, param);

            repository.Dispose();

            return Ok();
        }

        //GET api/{apiVersion}/Loan/BoardingStatus?aiBatchSkey=12345
        [HttpGet]
        [Route("BoardingStatus", Name = "GetLoanBoardingStatusV1")]
        [ResponseType(typeof(LoanBoardingStatusDTO))]
        public IHttpActionResult GetLoanBoardingStatus([FromUri] int aiBatchSkey)
        {
            var service = new LoanBoardingStatusService();
            var repository = new LoanBoardingStatusRepository(new ReverseQuestEntities());
            var result = service.GetEntityBySkey(repository, aiBatchSkey);

            repository.Dispose();
            return Ok(result);
        }

        //GET api/{apiVersion}/Loan/BoardingResult?aiBatchSkey=12345
        [HttpGet]
        [Route("BoardingResult", Name = "GetLoanBoardingResultV1")]
        [ResponseType(typeof(IEnumerable<LoanBoardingStatusDTO>))]
        public IHttpActionResult GetLoanBoardingResult([FromUri] int aiBatchSkey)
        {
            var service = new LoanBoardingResultService();
            var repository = new LoanBoardingResultRepository(new ReverseQuestEntities());
            var result = service.GetEntityBySkey(repository, aiBatchSkey);

            repository.Dispose();
            return Ok(result);
        }
    }
}