namespace MvcTemplate.Services.Users
{
    using Contracts;
    using Data.Models;
    using Data.Repositories.Contracts;

    public class UsersService : IUsersService
    {
        private IRepository<User, string> users;

        public UsersService(IRepository<User, string> users)
        {
            this.users = users;
        }

        public User GetById(string id)
        {
            User user = this.users.GetById(id);
            return user;
        }
    }
}
