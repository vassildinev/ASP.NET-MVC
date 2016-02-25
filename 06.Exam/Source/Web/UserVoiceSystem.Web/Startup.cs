using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(UserVoiceSystem.Web.Startup))]

namespace UserVoiceSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
