using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ReverseQuest.Common.Routing;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services;

namespace ReverseQuest.API.Controllers.V1
{
    [ApiVersion1RoutePrefix("LoanDetails")]
    public class LoanDetailsController : ApiController
    {
        //GET api/{apiVersion}/LoanDetails/{skey}
        [HttpGet]
        [Route("{skey}", Name = "GetLoanDetailsV1")]
        [ResponseType(typeof(LoanDetailsDTO))]
        public IHttpActionResult GetLoan([FromUri] int skey)
        {
            var service = new LoanDetailsService();
            var repository = new LoanDetailsRepository(new ReverseQuestEntities());
            var result = service.GetEntityBySkey(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/LoanDetails/{skey}/Master
        [HttpGet]
        [Route("{skey}/Master", Name = "GetLoanMasterInformationV1")]
        [ResponseType(typeof(LoanMasterDTO))]
        public async Task<IHttpActionResult> GetLoanMasterInformation([FromUri] int skey)
        {
            var service = new LoanMasterService();
            var repository = new LoanMasterRepository(new ReverseQuestEntities());
            var result = await service.GetEntityBySkeyAsync(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/LoanDetails/{skey}/Rates
        [HttpGet]
        [Route("{skey}/Rates", Name = "GetLoanRatesV1")]
        [ResponseType(typeof(LoanRatesDTO))]
        public IHttpActionResult GetLoanRates([FromUri] int skey)
        {
            var service = new LoanRatesService();
            var result = service.GetEntityBySkey(null, skey);

            return Ok(result);
        }

        //GET api/{apiVersion}/LoanDetails/{skey}/LoanServicerInformation
        [HttpGet]
        [Route("{skey}/LoanServicerInformation", Name = "GetLoanLoanServicerInformationV1")]
        [ResponseType(typeof(LoanServicerDTO))]
        public IHttpActionResult GetLoanLoanServicerInformation([FromUri] int skey)
        {
            var service = new LoanServicerService();
            var result = service.GetEntityBySkey(null, skey);

            return Ok(result);
        }

        //GET api/{apiVersion}/LoanDetails/{skey}/LoanBalance
        [HttpGet]
        [Route("{skey}/LoanBalance", Name = "GetLoanBalanceV1")]
        [ResponseType(typeof(LoanBalanceDTO))]
        public IHttpActionResult GetLoanLoanBalance([FromUri] int skey)
        {
            var service = new LoanBalanceService();
            var repository = new LoanBalanceRepository(new ReverseQuestEntities());
            var result = service.GetEntityBySkey(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/LoanDetails/{skey}/ContactDetails
        [HttpGet]
        [Route("{skey}/ContactDetails", Name = "GetLoanContactDetailsV1")]
        [ResponseType(typeof(IEnumerable<LoanContactDetailsDTO>))]
        public IHttpActionResult GetLoanContactDetails([FromUri] int skey)
        {
            var service = new LoanContactService();
            var repository = new LoanContactDetailsRepository(new ReverseQuestEntities());
            var result = service.GetListBySkey(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/LoanDetails/{skey}/ContactDetails/Image
        [HttpGet]
        [Route("{skey}/ContactDetails/Image", Name = "GetLoanContactImageV1")]
        [ResponseType(typeof(Image))]
        public IHttpActionResult GetLoanContactDetailsImage([FromUri] int skey)
        {
            var service = new LoanContactService();
            var repository = new LoanContactDetailsRepository(new ReverseQuestEntities());
            var result = service.GetListBySkey(repository, skey);

            repository.Dispose();

            var loanContactDetailsDTO = result.FirstOrDefault();
            if (loanContactDetailsDTO != null)
            {
                Image deserializedImage = null;
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                using (var memoryStream = new MemoryStream(Convert.FromBase64CharArray(loanContactDetailsDTO.ContactSignatureImage), false))
                {
                    deserializedImage = (Image)formatter.Deserialize(memoryStream);
                }

                return Ok(deserializedImage);
            }
                
            else
                return NotFound();
        }

        //POST api/{apiVersion}/LoanDetails/{skey}/ContactDetails
        [HttpPost]
        [Route("{skey}/ContactDetails", Name = "PostLoanContactDetailsV1")]
        [ResponseType(typeof(LoanContactDetailsDTO))]
        public IHttpActionResult PostLoanContactDetails([FromBody]LoanContactDetailsDTO loanContactDetailsDTO,
            [FromUri]int skey)
        {
            var service = new LoanContactService();
            var repository = new LoanContactInsertRepository(new ReverseQuestEntities());
            var result = service.AddEntity(repository, loanContactDetailsDTO);

            repository.Dispose();

            return Ok(result);
        }

        //PUT api/{apiVersion}/LoanDetails/{skey}/Master
        [HttpPut]
        [Route("{skey}/Master", Name = "PutLoanMasterInformationV1")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLoanMasterInformation([FromBody]LoanMasterDTO loanMasterDTO, [FromUri] int skey)
        {
            var service = new LoanMasterService();
            var repository = new LoanMasterRepository(new ReverseQuestEntities());
            await service.UpdateEntityBySkeyAsync(repository, loanMasterDTO, skey);

            repository.Dispose();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //PUT api/{apiVersion}/LoanDetails/{skey}/ContactDetails/{contactSkey}
        [HttpPut]
        [Route("{skey}/ContactDetails/{contactSkey}", Name = "PutLoanContactDetailsV1")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoanContactDetails([FromBody]LoanContactDetailsDTO loanContactDetailsDTO, 
            [FromUri]int skey, [FromUri]int contactSkey)
        {

            var service = new LoanContactService();
            var repository = new LoanContactUpdateRepository(new ReverseQuestEntities());
            service.UpdateEntityBySkey(repository, loanContactDetailsDTO, contactSkey);

            repository.Dispose();

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}