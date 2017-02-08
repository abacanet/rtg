using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ReverseQuest.Common.Routing;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories;
using ReverseQuest.Domain.DataTransformationObjects.Loan;
using ReverseQuest.Domain.Services;

namespace ReverseQuest.API.Controllers.V1
{
    [ApiVersion1RoutePrefix("LoanDetails/{skey}/Property")]
    public class LoanDetailsPropertyController : ApiController
    {
        //GET api/{apiVersion}/LoanDetails/{skey}/Property
        [HttpGet]
        [Route("", Name = "GetLoanPropertyV1")]
        [ResponseType(typeof(LoanPropertyDTO))]
        public IHttpActionResult GetLoanProperty([FromUri] int skey)
        {
            var service = new LoanPropertyService();
            var repository = new LoanPropertyDetailsRepository(new ReverseQuestEntities());
            var result = service.GetEntityBySkey(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //GET api/{apiVersion}/LoanDetails/{skey}/Property/Values
        [HttpGet]
        [Route("Values", Name = "GetLoanPropertyValuesV1")]
        [ResponseType(typeof(IEnumerable<LoanPropertyValueDTO>))]
        public IHttpActionResult GetLoanPropertyValues([FromUri] int skey)
        {
            var service = new LoanPropertyValueService();
            var repository = new LoanPropertyValuesDetailsRepository(new ReverseQuestEntities());
            var result = service.GetListBySkey(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //POST api/{apiVersion}/LoanDetails/{skey}/Property/Values
        [HttpPost]
        [Route("Values", Name = "PostLoanPropertyValuesDetailsV1")]
        [ResponseType(typeof(LoanPropertyValueDTO))]
        public IHttpActionResult PostLoanPropertyValueDetails([FromBody]LoanPropertyValueDTO loanPropertyValueDTO,
            [FromUri]int skey)
        {
            var service = new LoanPropertyValueService();
            var repository = new LoanPropertyInsertRepository(new ReverseQuestEntities());
            var result = service.AddEntity(repository, loanPropertyValueDTO);

            repository.Dispose();

            return Ok(result);
        }

        //PUT api/{apiVersion}/LoanDetails/{skey}/Property/
        [HttpPut]
        [Route("", Name = "PutLoanPropertyDetailsV1")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoanPropertyDetails([FromBody]LoanPropertyDTO loanPropertyDTO,
            [FromUri]int skey)
        {
            var service = new LoanPropertyService();
            var repository = new LoanPropertyUpdateRepository(new ReverseQuestEntities());
            service.UpdateEntityBySkey(repository, loanPropertyDTO, skey);

            repository.Dispose();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //PUT api/{apiVersion}/LoanDetails/{skey}/Property/Values/{propertyValueSkey}
        [HttpPut]
        [Route("Values/{propertyValueSkey}", Name = "PutLoanPropertyValuesDetailsV1")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoanPropertyValueDetails([FromBody]LoanPropertyValueDTO loanPropertyValueDTO,
            [FromUri]int skey, [FromUri]int propertyValueSkey)
        {
            var service = new LoanPropertyValueService();
            var repository = new LoanPropertyValueUpdateRepository(new ReverseQuestEntities());
            service.UpdateEntityBySkey(repository, loanPropertyValueDTO, skey);

            repository.Dispose();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //DELETE api/{apiVersion}/LoanDetails/{skey}/Property/Values/{propertyValueSkey}
        [HttpDelete]
        [Route("Values/{propertyValueSkey}", Name = "DeleteLoanPropertyValuesDetailsV1")]
        [ResponseType(typeof(LoanPropertyValueDTO))]
        public IHttpActionResult DeleteLoanPropertyValueDetails([FromUri]int skey, [FromUri]int propertyValueSkey)
        {
            var service = new LoanPropertyValueService();
            var repositoryGet = new LoanPropertyValuesDetailsRepository(new ReverseQuestEntities());
            var propertyValue = service.GetListBySkey(repositoryGet, skey).FirstOrDefault(v => v.PropertyValueSkey == propertyValueSkey);

            if (propertyValue == null)
                return NotFound();

            var repositoryDelete = new LoanPropertyValueDeleteRepository(new ReverseQuestEntities());
            service.DeleteEntityBySkey(repositoryDelete, skey);

            repositoryGet.Dispose();
            repositoryDelete.Dispose();

            return Ok(propertyValue);
        }

    }
}