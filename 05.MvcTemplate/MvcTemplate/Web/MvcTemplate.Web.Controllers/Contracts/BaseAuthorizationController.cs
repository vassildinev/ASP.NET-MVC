namespace MvcTemplate.Web.Controllers.Contracts
{
    using Services.Users.Contracts;
    using System.Web.Mvc;

    [Authorize]
    public abstract class BaseAuthorizationController : BaseController
    {
        public BaseAuthorizationController(IUsersService users)
            : base(users)
        {
        }
    }
}
