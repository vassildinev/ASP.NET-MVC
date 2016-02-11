using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocializR.Web.App.Startup))]
namespace SocializR.Web.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
