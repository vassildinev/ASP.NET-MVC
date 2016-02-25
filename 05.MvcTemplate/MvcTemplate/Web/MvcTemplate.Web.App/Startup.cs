[assembly: Microsoft.Owin.OwinStartup(typeof(MvcTemplate.Web.App.Startup))]
namespace MvcTemplate.Web.App
{
    using System;

    using Data;
    using Data.Models;
    using Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new MvcTemplateDbContext());
            app.CreatePerOwinContext(
                (IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) => 
                new ApplicationUserManager(
                    new UserStore<User>(context.Get<MvcTemplateDbContext>()), 
                    options));
            app.CreatePerOwinContext(
                (IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context) => 
                new ApplicationSignInManager(
                    context.GetUserManager<ApplicationUserManager>(), 
                    context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}
