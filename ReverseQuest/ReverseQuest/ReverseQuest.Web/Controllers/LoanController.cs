using ReverseQuest.Classes.Helpers;
using ReverseQuest.Classes.Models.LoanModule;
using ReverseQuest.Classes.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ReverseQuest.Web.Controllers
{
    public class LoanController : Controller
    {
        [Route("Loan/GetLoanBalance")]
        [HttpGet]
        public async Task<JsonResult> GetLoanBalance(int sKey)
        {
            CustomDelegatingHandler customDelegatingHandler = null;
            List<Tuple<string, string>> headers = null;
            string url = Global.ReverseQuestDevAPIUrl + "LoanDetails/" + sKey + "/LoanBalance"; //569701,562441,43697
            LoanBalanceDTO loanBalanceDTO = await HttpHelper.HttpGetAsync<LoanBalanceDTO>(url, customDelegatingHandler, headers);
            LoanBalanceVM loanBalance = LoanBalanceDTO.convertModelToVM(loanBalanceDTO);
            return Json(loanBalance, JsonRequestBehavior.AllowGet);
        }

        [Route("Loan/GetLoanDetail")]
        [HttpGet]
        public async Task<JsonResult> GetLoanDetail(int sKey)
        {
            CustomDelegatingHandler customDelegatingHandler = null;
            List<Tuple<string, string>> headers = null;
            //string url = Global.ReverseQuestAPIUrl + "LoanDetails/123?" + Global.AuthToken + "&" + Global.ClientRequestId;
            string url = Global.ReverseQuestDevAPIUrl + "LoanDetails/" + sKey;
            LoanDetailDTO loanDetailDTO = await HttpHelper.HttpGetAsync<LoanDetailDTO>(url, customDelegatingHandler, headers);
            LoanDetailVM loanDetails = LoanDetailDTO.convertModelToVM(loanDetailDTO);
            return Json(loanDetails, JsonRequestBehavior.AllowGet);
        } 
    }
}