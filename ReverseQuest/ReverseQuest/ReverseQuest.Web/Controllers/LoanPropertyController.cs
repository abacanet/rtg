using Newtonsoft.Json;
using ReverseQuest.API.DataTransformationObjects.Loan;
using ReverseQuest.Classes.Helpers;
using ReverseQuest.Classes.Models.LoanModule;
using ReverseQuest.Classes.Models.Shared.Lists;
using ReverseQuest.Classes.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ReverseQuest.Web.Controllers
{
    public class LoanPropertyController : Controller
    {
        

        //[Route("LoanBoarding/Upload")]
        //[HttpPost]
        //public async Task<ActionResult> Upload(IEnumerable<HttpPostedFileBase> files, LoanBoardingVM viewModel)
        //{
        //    if (files != null)
        //    {
        //        var batchSkey = await GetBatchSkey();
        //        //List<LoanMasterDTO> loans = LoanBoardingVM.ConvertFilesToLoans(files);
        //        foreach (var file in files)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var period = fileName.LastIndexOf('.');
        //            fileName = fileName.Insert(period, "_" + batchSkey.ToString());
        //            var physicalPath = Path.Combine(
        //                   Server.MapPath(ConfigurationManager.AppSettings["UploadDirectory"]), fileName);
        //            file.SaveAs(physicalPath);
        //        }
        //        // Return an empty string to signify success
        //        return Json(new { status = "Batch " + batchSkey.ToString() + " is processing" }, "text/plain");
        //    }
        //    return Content("There were no files to upload.  Nothing processing...");
        //}


        //private async Task<int> GetBatchSkey()
        //{
        //    //CustomDelegatingHandler customDelegatingHandler = null;
        //    var content = new StringContent("");
        //    List<Tuple<string, string>> headers = null;
        //    string url = Global.ReverseQuestDevAPIUrl + "SystemParameters/NextSystemKey?avcSystemKeyName=BATCH_SKEY_LOAN_BOARD&aiNumberOfSkeys=1";
        //    var response = await HttpHelper.HttpPostAsync(url, content, null, headers);
        //    var batchSkey = await response.Content.ReadAsStringAsync();
        //    return Convert.ToInt32(batchSkey);
        //}

       

        private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
        {
            return
                from a in files
                where a != null
                select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
        }


        [Route("LoanProperty/Details")]
        [HttpGet]
        public async Task<JsonResult> Details(int? sKey)
        {
            CustomDelegatingHandler customDelegatingHandler = null;
            List<Tuple<string, string>> headers = null;
            string url = Global.ReverseQuestDevAPIUrl + "LoanDetails/" + sKey + "/Property"; 
            LoanPropertyDTO dto = await HttpHelper.HttpGetAsync<LoanPropertyDTO>(url, customDelegatingHandler, headers);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [Route("LoanProperty/Values")]
        [HttpGet]
        public async Task<JsonResult> Values(int? sKey)
        {
            CustomDelegatingHandler customDelegatingHandler = null;
            List<Tuple<string, string>> headers = null;
            string url = Global.ReverseQuestDevAPIUrl + "LoanDetails/" + sKey + "/Property/Values"; 
            List<LoanPropertyValueDTO> dto = await HttpHelper.HttpGetAsync<List<LoanPropertyValueDTO>>(url, customDelegatingHandler, headers);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

    }
}

