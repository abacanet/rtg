using System.Web;
using System.Web.Mvc;

namespace ReverseQuestWeb.Classes
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool disableAuthentication = false;
#if DEBUG
            disableAuthentication = true;
#endif

            if (disableAuthentication)
                return true;

            return base.AuthorizeCore(httpContext);
        }
    }
}