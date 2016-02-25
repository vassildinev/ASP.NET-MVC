namespace MvcTemplate.Web.Configurations
{
    using System.Web.Mvc;

    using Infrastructure.ViewEngines;

    public static class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();

            var lightweightRazorViewEngine = new LightweightRazorViewEngine();
            viewEngines.Add(lightweightRazorViewEngine);
        }
    }
}
