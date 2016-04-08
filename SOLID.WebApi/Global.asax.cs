using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SOLID.IoC;

namespace SOLID.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            var dependencyInjectionProvider = new DependencyInjectionProvider();
            dependencyInjectionProvider.Initialize(GlobalConfiguration.Configuration);

            // Remove the XML Formatter from the web api
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
