
using Newtonsoft.Json;
using ReverseQuest.API.DataTransformationObjects.Loan;
using ReverseQuest.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ReverseQuest.Web.Controllers
{
    public class LoanContactController : Controller
    {
        [Route("LoanContact/GetLoanContacts")]
        [HttpGet]
        public async Task<JsonResult> GetLoanContacts(int? sKey)
        {
            CustomDelegatingHandler customDelegatingHandler = null;
            List<Tuple<string, string>> headers = null;
            string url = Global.ReverseQuestDevAPIUrl + "LoanDetails/" + sKey + "/ContactDetails"; //569701,562441,43697
            List<LoanContactDetailsDTO> dto = await HttpHelper.HttpGetAsync<List<LoanContactDetailsDTO>>(url, customDelegatingHandler, headers);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }


        [Route("LoanContact/Update")]
        [HttpPost]
        public async Task<JsonResult> Update(LoanContactDetailsDTO dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(dto);
                var mediaType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage response =
                    await client.PutAsync(Global.ReverseQuestDevAPIUrl + "LoanDetails/" + dto.LoanSkey.ToString() + "/ContactDetails/" + dto.ContactSkey.ToString(), new StringContent(json, Encoding.UTF8, "application/json")))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception((int)response.StatusCode + "-" + response.StatusCode.ToString());
                    }
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [Route("LoanContact/Create")]
        [HttpPost]
        public async Task<JsonResult> Create(LoanContactDetailsDTO dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            List<Tuple<string, string>> headers = null;
            string url = Global.ReverseQuestDevAPIUrl + "LoanDetails/" + dto.LoanSkey + "/ContactDetails";
            var response = await HttpHelper.HttpPostAsync(url, content, null, headers);
            var responseContent = await response.Content.ReadAsStringAsync();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}