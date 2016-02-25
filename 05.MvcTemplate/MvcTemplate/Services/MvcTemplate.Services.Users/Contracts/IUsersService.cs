namespace MvcTemplate.Services.Users.Contracts
{
    using Data.Models;

    public interface IUsersService
    {
        User GetById(string id);
    }
}
