using System.Web.Http;
using ReverseWebQuest.Common.Routing;

namespace ReverseQuestWeb.Controllers.V1
{
    [ApiVersion1RoutePrefix("VersioningTest")]
    public class VersioningTestController : ApiController
    {
        [Route("", Name = "TestVersionV1")]
        [HttpGet]
        public IHttpActionResult TestVersion()
        {
            return Ok("version 1");
        }
    }
}