namespace SocializR.Data.Contracts
{
    using Models;
    using Repositories.Contracts;

    public interface ISocializRData
    {
        IRepository<User> UsersRepository { get; }

        IRepository<Shout> ShoutsRepository { get; }

        int SaveChanges();
    }
}
