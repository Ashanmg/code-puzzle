using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Puzzle.WebApp.Infrastructure;

namespace Puzzle.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Create the container builder
            var builder = new ContainerBuilder();

            // Register your modules
            builder.RegisterModule(new DependencyRegistar());

            // Register the controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Build the container
            var container = builder.Build();

            // Set the dependency resolver to use Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }
    }
}
