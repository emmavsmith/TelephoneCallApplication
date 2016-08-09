using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MPD.Interviews.Common.Logging;
using MPD.Interviews.Domain;
using MPD.Interviews.Interfaces.Logging;
using MPD.Interviews.Interfaces.Repositories;
using MPD.Interviews.Repository;
using MPD.Interviews.WebApplication.Mapping;
using MPD.Interviews.WebApplication.Services;
using MPD.Interviews.WebApplication.Services.Interfaces;

namespace MPD.Interviews.WebApplication.DI
{
    public class ContainerConfiguration : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IConnectionProvider>().ImplementedBy<ConnectionProvider>().LifestyleTransient(),
                Component.For<ILogger>().ImplementedBy<Logger>().LifestyleTransient(),
                Component.For<IRepository<CallDetails>, ICallDetailsSearchRepository>().ImplementedBy<CallDetailsRepository>().LifestylePerWebRequest(),
                Component.For<IRepository<User>>().ImplementedBy<UserRepository>().LifestylePerWebRequest(),
                Component.For<IMapper>().UsingFactoryMethod(MappingConfiguration.ConfigureMaps).LifestyleSingleton(),
                Component.For<ICallDetailsService>().ImplementedBy<CallDetailsService>().LifestylePerWebRequest(),
                Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest()
                );

            RegisterControllers(container);
        }

        private static void RegisterControllers(IWindsorContainer container)
        {
            var controllers =
                Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof (Controller)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}