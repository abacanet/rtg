using ReverseQuest.Classes.Helpers;
using ReverseQuest.Classes.Models.LoanModule;
using ReverseQuest.Classes.Models.LoanModule.LoanSearch;
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
    public class LoanSearchController : Controller
    {
        //public static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
        //{
        //    return from p in obj.GetType().GetProperties()
        //           where p.PropertyType == typeof(T)
        //           select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));
        //}


        [Route("LoanSearch/GetLoanSearchResults")]
        [HttpPost]
        public async Task<JsonResult> GetLoanSearchResults(LoanSearchParameterDTO searchParameters)
        {
            var parameters = "";
            var properties = searchParameters.GetType().GetProperties();
            foreach (var property in properties)
            {
                var name = property.Name;
                var val = property.GetValue(searchParameters);
                if (val != null)
                {
                    parameters += "&" + name + "=" + val;
                }
            }
            System.Diagnostics.Debug.Write(parameters);

            CustomDelegatingHandler customDelegatingHandler = null;
            List<Tuple<string, string>> headers = null;
            string url = Global.ReverseQuestDevAPIUrl + "Loan/Search?aiPageNumber=1&aiNumberOfRecords=100" + parameters; 
            List<LoanSearchDTO> data = await HttpHelper.HttpGetAsync<List<LoanSearchDTO>>(url, customDelegatingHandler, headers);
            return Json(data, JsonRequestBehavior.AllowGet);


            //aiPageNumber ={ aiPageNumber}
            //&aiNumberOfRecords ={ aiNumberOfRecords}
            //&aiLoanSKey ={ aiLoanSKey}
            //&avcOriginalLoanNumber ={ avcOriginalLoanNumber}
            //&avcFhaCaseNumber ={ avcFhaCaseNumber}
            //&avcInvestorLoanNumber ={ avcInvestorLoanNumber}
            //&avcPriorServicerLoanNumber ={ avcPriorServicerLoanNumber}
            //&avcLoanStatus ={ avcLoanStatus}
            //&avcLoanSubStatusCodes ={ avcLoanSubStatusCodes}
            //&avcContactFirstName ={ avcContactFirstName}
            //&avcContactLastName ={ avcContactLastName}
            //&avcContactPhoneNumber ={ avcContactPhoneNumber}
            //&avcContactTypeSKeys ={ avcContactTypeSKeys}
            //&avcPropertyAddress ={ avcPropertyAddress}
            //&avcPropertyCity ={ avcPropertyCity}
            //&avcPropertyStateCodes ={ avcPropertyStateCodes}
            //&avcPropertyZipCode ={ avcPropertyZipCode}
            //&avcLoanServicerSKeys ={ avcLoanServicerSKeys}
            //&avcInvestorSKeys ={ avcInvestorSKeys}
            //&avcLoanPoolSKeys ={ avcLoanPoolSKeys}
            //&avcProductTypeSKeys ={ avcProductTypeSKeys}
            //&avcPaymentPlanTypes ={ avcPaymentPlanTypes}
            //&avcArmTypes ={ avcArmTypes}
            //&avcRateIndexTypeSKeys ={ avcRateIndexTypeSKeys}
            //&avcSpocsKey ={ avcSpocsKey}
            //&adtmBoardedDateFrom ={ adtmBoardedDateFrom}
            //&adtmBoardedDateTo ={ adtmBoardedDateTo}
            //&avcBoardingType ={ avcBoardingType}
            //&avcCreditType ={ avcCreditType}
            //&avcIncludeAlerts ={ avcIncludeAlerts}
            //&avcExcludeAlerts ={ avcExcludeAlerts}
            //&avcIncludeDocs ={ avcIncludeDocs}
            //&avcExcludeDocs ={ avcExcludeDocs}
            //&avcSortColumn ={ avcSortColumn}
            //&avcSortOrder ={ avcSortOrder}
        }
    }
}