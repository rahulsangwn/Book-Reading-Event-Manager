using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Project.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        { 
            //var container = ContainerConfigBLL.Configure();  // For autofac dependency injection
            //DependencyResolver.SetResolver(container);
            //GlobalFilters.Filters.Add(new AuthorizeAttribute()); // Global Authorization Attribulte
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
