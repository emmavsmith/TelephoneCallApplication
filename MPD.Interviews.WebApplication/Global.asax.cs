using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using MPD.Interviews.WebApplication.DI;

namespace MPD.Interviews.WebApplication
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterDi();
        }

        private void RegisterDi()
        {
            var container = new WindsorContainer().Install(new ContainerConfiguration());

            var controllerFactory = new ControllerFactory(container.Kernel);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}