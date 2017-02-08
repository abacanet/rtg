using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReverseQuestWeb.Controllers
{
    public class LoanModuleBaseController : ModuleBaseController
    {        
        public LoanModuleBaseController()
        {
            ViewBag.ModuleTitle = "Loan Module1";
            
            return;
        }
    }
}