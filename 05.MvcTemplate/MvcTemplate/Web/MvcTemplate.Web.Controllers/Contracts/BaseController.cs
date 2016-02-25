namespace MvcTemplate.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Users.Contracts;

    public abstract class BaseController : Controller
    {
        protected IUsersService users;

        public BaseController(IUsersService users)
        {
            this.users = users;
        }

        protected User CurrentUser { get; set; }

        private User SetCurrentUser()
        {
            string currentUserId = this.User.Identity.GetUserId();
            return this.users.GetById(currentUserId);
        }
    }
}
