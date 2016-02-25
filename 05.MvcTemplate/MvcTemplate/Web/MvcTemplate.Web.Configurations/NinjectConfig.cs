[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(MvcTemplate.Web.Configurations.NinjectConfig),
    nameof(MvcTemplate.Web.Configurations.NinjectConfig.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(
    typeof(MvcTemplate.Web.Configurations.NinjectConfig),
    nameof(MvcTemplate.Web.Configurations.NinjectConfig.Stop))]

namespace MvcTemplate.Web.Configurations
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    
    using Infrastructure.Registries.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Common.Constants;

    public class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            Assembly.Load(Assemblies.WebInfrastructure)
                .GetExportedTypes()
                .Where(type => type.IsClass && typeof(INinjectRegistry).IsAssignableFrom(type))
                .ToList()
                .ForEach(registry =>
                {
                    var registryInstance = (INinjectRegistry)Activator.CreateInstance(registry);
                    registryInstance.Register(kernel);
                });
        }
    }
}