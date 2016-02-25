namespace MvcTemplate.Web.Infrastructure.Registries
{
    using System;
    using System.Linq;

    using Contracts;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public class ServicesRegistry : INinjectRegistry
    {
        private const string ServicesAssembliesPrefix = "MvcTemplate.Services";

        public void Register(IKernel kernel)
        {
            AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Select(assembly => assembly.GetName().Name)
                .Where(assemblyName => assemblyName.Contains(ServicesAssembliesPrefix))
                .ToList()
                .ForEach(assemblyName =>
                {
                    kernel
                    .Bind(b => b.From(assemblyName)
                    .SelectAllClasses()
                    .BindDefaultInterface()
                    .Configure(x => x.InRequestScope()));
                });
        }
    }
}
