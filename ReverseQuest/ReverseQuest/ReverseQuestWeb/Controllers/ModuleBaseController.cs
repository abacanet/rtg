using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ReverseQuestWeb.Models;
using System.Security;
using System.Threading;

namespace ReverseQuestWeb.Controllers
{
    public class ModuleBaseController : Controller
    {
        public ModuleBaseController()
        {
            ViewBag.UserName = Thread.CurrentPrincipal.Identity.Name == ""? "NO one here" :Thread.CurrentPrincipal.Identity.Name;
            ViewBag.ModuleTitle = "";

            return;
        }
    }
}