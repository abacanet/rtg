using System.Web.Mvc;

namespace ReverseQuest.API.Controllers.V1
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
