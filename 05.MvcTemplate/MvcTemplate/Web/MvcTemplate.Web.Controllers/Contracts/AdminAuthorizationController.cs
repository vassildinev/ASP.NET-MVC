namespace MvcTemplate.Web.Controllers.Contracts
{
    using System.Web.Mvc;

    using Common;
    using Services.Users.Contracts;

    [Authorize(Roles = Roles.AdminRoleName)]
    public class AdminAuthorizationController : BaseController
    {
        public AdminAuthorizationController(IUsersService users)
            : base(users)
        {
        }
    }
}
