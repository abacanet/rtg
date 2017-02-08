using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReverseQuestWeb.Controllers
{
    public class DashboardController : DashboardModuleBaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";

            return View();
        }
    }
}
