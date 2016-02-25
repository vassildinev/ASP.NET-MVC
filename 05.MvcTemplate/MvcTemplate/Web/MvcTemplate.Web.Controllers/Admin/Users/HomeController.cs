namespace MvcTemplate.Web.Controllers.Admin.Users
{
    using System.Web.Mvc;

    using Contracts;
    using Services.Users.Contracts;

    public class HomeController : AdminAuthorizationController
    {
        public HomeController(IUsersService users)
            : base(users)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
