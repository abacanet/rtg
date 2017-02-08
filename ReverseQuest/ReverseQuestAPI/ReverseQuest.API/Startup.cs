using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ReverseQuest.API.Startup))]

namespace ReverseQuest.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
