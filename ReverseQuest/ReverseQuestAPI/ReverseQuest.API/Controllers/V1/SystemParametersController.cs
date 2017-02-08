using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using ReverseQuest.Common.Routing;
using ReverseQuest.Data.Models;
using ReverseQuest.Data.Repositories;
using ReverseQuest.Domain.Services;

namespace ReverseQuest.API.Controllers.V1
{
    [ApiVersion1RoutePrefix("SystemParameters")]
    public class SystemParametersController : ApiController
    {
        //POST api/{apiVersion}/SystemParameters/NextSystemKey?avcSystemKeyName=BATCH_SKEY_LOAN_BOARD&aiNumberOfSkeys=1
        [HttpPost]
        [Route("NextSystemKey", Name = "ObtainNextSystemKeyV1")]
        [ResponseType(typeof(int))]
        public IHttpActionResult ObtainNextSystemKey(
            [FromUri] string avcSystemKeyName,
            [FromUri] int? aiNumberOfSkeys = null)
        {
            var param = new Dictionary<string, object>
            {
                {"avcSystemKeyName", avcSystemKeyName},
                {"aiNumberOfSkeys", aiNumberOfSkeys}
            };

            var service = new NextSystemKeyService();
            var repository = new GetNextSystemKeyRepository(new ReverseQuestEntities());
            var result = service.GetPrimitiveTypeByParameter(repository, param);

            repository.Dispose();

            return Ok(result);
        }

    }
}