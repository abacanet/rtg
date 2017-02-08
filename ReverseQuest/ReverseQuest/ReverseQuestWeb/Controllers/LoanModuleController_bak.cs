using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ReverseQuestWeb.Models;

namespace ReverseQuestWeb.Controllers
{

    public class LoanModuleController_bak : ApiController
    {
        private ReverseQuestEntities rqe = new ReverseQuestEntities();

        // GET api/LoanModule
        [System.Web.Http.Route("api/LoanModule/{loanSkey}/{pageNumber}/{numberOfRecords}")]
        [System.Web.Http.AcceptVerbs("GET")]
        public dynamic Get(int loanSkey, int pageNumber, int numberOfRecords)
        { 
            return new string[] { loanSkey.ToString(), pageNumber.ToString(), numberOfRecords.ToString() };

        }

        //[ResponseType(typeof(app_alert))]
        //[System.Web.Http.AcceptVerbs("GET")]
        //[Authorize(Roles = "Users")]
        [System.Web.Http.Route("api/LoanModule/{loanSkey}/{originalLoanNumber}/{pageNumber}/{numberOfRecords}")]
        public app_alert Get(int loanSkey, int originalLoanNumber, int pageNumber, int numberOfRecords)
        {
          //  var results = rqe.usp_GetResultsLoanSearch(/*LoanSkey*/ null, /*Original Loan Number*/null,/*FHA Case Number*/ null,
          ///*Investor loan number*/ null,/*Prior Servicer Loan Number*/ null, /*Loan Status*/null,/*Loan Sub Status Code */ null,
          ///*Contact First Name*/ null, /* Contact Last Name */ null, /*Contact Phone Number */ null, /*Contact Type Skeys */ null,
          ///*Property Address */ null,/* Property City */ null,/*Property State */null, /*Property Zip Code */ null,
          ///*Loan Servicer Skeys*/ null,/*Investor Skeys*/ null,/*loan Pool Skeys*/null, /*Product Type Skeys */ null,
          ///*Payment Plan Type*/ null,/*ARM Types */ null,/*Rate Index Type Skeys*/ null,/*SPOCskey*/ null,
          ///*Boarded Date From */ null, /*Boarded Date To*/ null, /*Boarding Type*/ null,/*CreditType*/ null,
          ///*Include Alerts*/ null,/*Exclude Alerts */ null,/*Include Docs*/null, /*Exclude Docs*/ null, /*Page Number */ pageNumber,
          ///*Number of Records*/ numberOfRecords, /*Sort Column*/null, /*Sort Order*/ null);

            ///if (loanSkey == 0)
            //
           //     return NotFound();
           // }

            app_alert a = new app_alert();
            a.loan_skey = 10;
            a.alert_note = "This is a test Alert Note";
            a.modified_date = (DateTime?)DateTime.Now;
            a.modified_by = "test";

            return a; //Ok(a);
            //new string[] { "value1", "value2" };
        }
    }
}
