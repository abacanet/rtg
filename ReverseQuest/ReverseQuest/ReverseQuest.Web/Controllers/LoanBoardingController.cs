using Newtonsoft.Json;
using ReverseQuest.Classes.Helpers;
using ReverseQuest.Classes.Models.LoanModule;
using ReverseQuest.Classes.Models.Shared.Lists;
using ReverseQuest.Classes.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ReverseQuest.Web.Controllers
{
    public class LoanBoardingController : Controller
    {
        /// <summary>
        /// step 1 for loan boarding
        /// </summary>
        /// <returns></returns>
        [Route("LoanBoarding/GetBatchSkey")]
        [HttpGet]
        public async Task<int> GetBatchSkey()
        {
            var content = new StringContent("");
            List<Tuple<string, string>> headers = null;
            string url = Global.ReverseQuestDevAPIUrl + "SystemParameters/NextSystemKey?avcSystemKeyName=BATCH_SKEY_LOAN_BOARD&aiNumberOfSkeys=1";
            var response = await HttpHelper.HttpPostAsync(url, content, null, headers);
            var batchSkey = await response.Content.ReadAsStringAsync();
            return Convert.ToInt32(batchSkey);
        }

        /// <summary>
        /// step 2 for loan boarding
        /// </summary>
        /// <param name="files"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Route("LoanBoarding/Upload")]
        [HttpPost]
        public async Task<ActionResult> Upload(IEnumerable<HttpPostedFileBase> files, LoanBoardingVM viewModel)
        {
            if (files != null)
            {
                //var batchSkey = await GetBatchSkey();
                foreach (var file in files)
                {
                    var fileName = "import_" + viewModel.BatchSkey.ToString() + ".txt";
                    // Get the object used to communicate with the server.
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ImportDomain"] + "/LoanBoarding/" + fileName);
                    request.Method = "STOR";
                    request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ImportUserName"], ConfigurationManager.AppSettings["ImportPassword"]);
                    request.UseBinary = true;
                    request.UsePassive = false;
                    request.KeepAlive = true;
                    BinaryReader binaryReader = new BinaryReader(file.InputStream);
                    byte[] data = binaryReader.ReadBytes(file.ContentLength);
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    await ProcessFile(viewModel.BatchSkey, viewModel);
                }
                // Return an empty string to signify success
                return Json(new { status = "File Uploaded Success" }, "text/plain");
            }
            return Content("There were no files to upload.  Nothing processing...");
        }

        //X509Certificate2 GetCert()
        //{

        //    string certificatePath = Server.MapPath("../certificate/ftps-web1-Cert");
        //    var stx = System.IO.File.Open(certificatePath, FileMode.Open);
        //    using (BinaryReader br = new BinaryReader(stx))
        //    {
        //        return new X509Certificate2(br.ReadBytes((int)br.BaseStream.Length));
        //    }
        //}

        private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
        {
            return
                from a in files
                where a != null
                select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
        }


        /// <summary>
        /// step 3 loan boarding
        /// </summary>
        /// <param name="batchSkey"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private async Task<bool> ProcessFile(int batchSkey, LoanBoardingVM viewModel)
        {
            var content = new StringContent("");
            List<Tuple<string, string>> headers = null;
            string queryString = string.Format("Loan/ProcessLoanBoardingFile?aiBatchSkey={0}&aiLoanServicerSkey={1}&aiInvestorSkey={2}&aiLoanPoolSkey={3}&aiPropertyTypeCategorySkey={4}&acBoardingType={5}",
                batchSkey, viewModel.Servicer, viewModel.Investor, viewModel.InvestorPool, viewModel.CollateralCategory, viewModel.BoardingType);
            string url = Global.ReverseQuestDevAPIUrl + queryString;
            var response = await HttpHelper.HttpPostAsync(url, content, null, headers);
            return true;
        }




        [Route("LoanBoarding/GetInvestors")]
        [HttpGet]
        public async Task<JsonResult> GetInvestors(int clientId)
        {
            List<InvestorDTO> list = new List<InvestorDTO>();
            InvestorDTO investor = new InvestorDTO { Skey = 1, Name = "Investor 1" };
            InvestorDTO investor2 = new InvestorDTO { Skey = 2, Name = "Investor 2" };
            list.Add(investor);
            list.Add(investor2);
            await Task.Delay(1);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [Route("LoanBoarding/GetServicers")]
        [HttpGet]
        public async Task<JsonResult> GetServicers(int clientId)
        {
            List<ServicerDTO> list = new List<ServicerDTO>();
            ServicerDTO one = new ServicerDTO { Skey = 1, Name = "Servicer 1" };
            ServicerDTO two = new ServicerDTO { Skey = 2, Name = "Servicer 2" };
            list.Add(one);
            list.Add(two);
            await Task.Delay(1);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [Route("LoanBoarding/GetInvestorPools")]
        [HttpGet]
        public async Task<JsonResult> GetInvestorPools(int clientId)
        {
            List<LoanPoolDTO> list = new List<LoanPoolDTO>();
            LoanPoolDTO one = new LoanPoolDTO { Skey = 1, LongDescription = "Pool 1" };
            LoanPoolDTO two = new LoanPoolDTO { Skey = 2, LongDescription = "Pool 2" };
            list.Add(one);
            list.Add(two);
            await Task.Delay(1);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}


//public ActionResult Remove(string[] fileNames)
//{
//    // The parameter of the Remove action must be called "fileNames"

//    if (fileNames != null)
//    {
//        foreach (var fullName in fileNames)
//        {
//            var fileName = Path.GetFileName(fullName);
//            var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

//            // TODO: Verify user permissions

//            if (System.IO.File.Exists(physicalPath))
//            {
//                // The files are not actually removed in this demo
//                // System.IO.File.Delete(physicalPath);
//            }
//        }
//    }

//    // Return an empty string to signify success
//    return Content("");
//}

//[Route("LoanBoarding/Save")]
//[HttpPost]
//public ActionResult Save(LoanBoardingVM viewModel)
//{

//    var batchSkey = GetBatchSkey();

//    //foreach (var file in viewModel.Files)
//    //{                
//    //    if (file.ContentLength > 0)
//    //    {
//    //        var fileName = Path.GetFileName(file.FileName);
//    //        var path = Path.Combine(
//    //            Server.MapPath(ConfigurationManager.AppSettings["UploadDirectory"]), fileName);
//    //        file.SaveAs(path);
//    //    }
//    //}

//    return Content(batchSkey.ToString());
//}




//[HttpPost]
//public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
//{
//    if (files != null)
//    {
//        TempData["UploadedFiles"] = GetFileInfo(files);
//    }

//    return RedirectToRoute("Demo", new { section = "upload", example = "result" });
//}