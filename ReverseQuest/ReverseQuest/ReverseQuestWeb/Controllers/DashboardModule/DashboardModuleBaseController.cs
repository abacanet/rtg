using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReverseQuestWeb.Controllers
{
    public abstract class DashboardModuleBaseController : ModuleBaseController
    {        
        public DashboardModuleBaseController()
        {
            ViewBag.ModuleTitle = "Dashboard";
            
            return;
        }
    }
}