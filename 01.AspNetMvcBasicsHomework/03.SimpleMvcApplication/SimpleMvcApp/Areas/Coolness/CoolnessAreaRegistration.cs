using System.Web.Mvc;

namespace SimpleMvcApp.Areas.Coolness
{
    public class CoolnessAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Coolness";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Qko",
                url: "Coolness",
                defaults: new { controller = "Pesho", action = "Index" }
            );

            context.MapRoute(
                name:"Coolness_default",
                url: "Coolness/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}