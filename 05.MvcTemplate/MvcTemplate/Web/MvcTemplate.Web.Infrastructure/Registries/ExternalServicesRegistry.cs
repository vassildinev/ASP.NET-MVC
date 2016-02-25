namespace MvcTemplate.Web.Infrastructure.Registries
{
    using Contracts;
    using Ganss.XSS;
    using Ninject;
    using Ninject.Web.Common;

    public class ExternalServicesRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IHtmlSanitizer>().To<HtmlSanitizer>().InRequestScope();
        }
    }
}
