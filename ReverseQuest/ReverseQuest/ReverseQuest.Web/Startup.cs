using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReverseQuest.Web.Startup))]
namespace ReverseQuest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
