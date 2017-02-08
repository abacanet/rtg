using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using Microsoft.Owin.Security.OAuth;
using ReverseQuest.Common;
using ReverseQuest.Common.Routing;

namespace ReverseQuest.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //API Versioning registration
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
        }
    }
}
