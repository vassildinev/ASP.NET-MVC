namespace MvcTemplate.Web.Identity
{
    using Data.Models;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}
