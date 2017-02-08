

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Reversequest/LoanSearchResults", typeof(ReverseQuest.Reversequest.Pages.LoanSearchResultsController))]

namespace ReverseQuest.Reversequest.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Reversequest/LoanSearchResults"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.LoanSearchResultsRow))]
    public class LoanSearchResultsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Reversequest/LoanSearchResults/LoanSearchResultsIndex.cshtml");
        }
    }
}