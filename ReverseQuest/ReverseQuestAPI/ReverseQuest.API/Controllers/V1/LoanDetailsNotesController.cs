using System.Collections.Generic;
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
    [ApiVersion1RoutePrefix("LoanDetails/{skey}/Notes")]
    public class LoanDetailsNotesController : ApiController
    {
        //GET api/{apiVersion}/LoanDetails/{skey}/Notes
        [HttpGet]
        [Route("", Name = "GetLoanNotesV1")]
        [ResponseType(typeof(IEnumerable<LoanNotesDTO>))]
        public IHttpActionResult GetLoanNotes([FromUri] int skey)
        {
            var service = new LoanNotesService();
            var repository = new LoanNotesDetailsRepository(new ReverseQuestEntities());
            var result = service.GetListBySkey(repository, skey);

            repository.Dispose();

            return Ok(result);
        }

        //POST api/{apiVersion}/LoanDetails/{skey}/Notes
        [HttpPost]
        [Route("", Name = "PostLoanNotesV1")]
        [ResponseType(typeof(LoanNotesDTO))]
        public IHttpActionResult PostLoanNote([FromBody]LoanNotesDTO loanNotesDTO,
            [FromUri]int skey)
        {
            var service = new LoanNotesService();
            var repository = new LoanNoteInsertRepository(new ReverseQuestEntities());
            var result = service.AddEntity(repository, loanNotesDTO);

            repository.Dispose();

            return Ok(result);
        }

        //PUT api/{apiVersion}/LoanDetails/{skey}/Notes/{noteSkey}
        [HttpPut]
        [Route("{noteSkey}", Name = "PutLoanNotesV1")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoanNotes([FromBody]LoanNotesDTO loanNotesDTO,
            [FromUri]int skey, [FromUri] int noteSkey)
        {
            var service = new LoanNotesService();
            var repository = new LoanNotesUpdateRepository(new ReverseQuestEntities());
            service.UpdateEntityBySkey(repository, loanNotesDTO, noteSkey);

            repository.Dispose();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}