namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using Contracts;
    using Services.Users.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IUsersService users)
            : base(users)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Error()
        {
            return this.View();
        }
    }
}