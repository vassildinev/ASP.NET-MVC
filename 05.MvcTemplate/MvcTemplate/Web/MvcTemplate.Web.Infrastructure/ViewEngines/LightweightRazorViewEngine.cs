namespace MvcTemplate.Web.Infrastructure.ViewEngines
{
    using System.Web.Mvc;

    public class LightweightRazorViewEngine : RazorViewEngine
    {
        public LightweightRazorViewEngine()
        {
            this.AreaViewLocationFormats = new[]
            {
             "~/Views/{2}/{1}/{0}.cshtml",
             "~/Views/{2}/Shared/{0}.cshtml"
            };

            this.AreaMasterLocationFormats = new[]
            {
             "~/Areas/{2}/Views/{1}/{0}.cshtml",
             "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            this.AreaPartialViewLocationFormats = new[]
            {
             "~/Areas/{2}/Views/{1}/{0}.cshtml",
             "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            this.ViewLocationFormats = new[]
            {
             "~/Views/{1}/{0}.cshtml",
             "~/Views/Shared/{0}.cshtml"
            };

            this.MasterLocationFormats = new[]
            {
             "~/Views/{1}/{0}.cshtml",
             "~/Views/Shared/{0}.cshtml"
            };

            this.PartialViewLocationFormats = new[]
            {
             "~/Views/{1}/{0}.cshtml",
             "~/Views/Shared/{0}.cshtml"
            };

            this.FileExtensions = new[] { "cshtml" };
        }
    }
}
