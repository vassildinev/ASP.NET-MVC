namespace SocializR.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Contracts;
    using System.Data.Entity;

    public class SocializRDbContext : IdentityDbContext<User>, ISocializRDbContext
    {
        public SocializRDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Shout> Shouts { get; set; }

        public static SocializRDbContext Create()
        {
            return new SocializRDbContext();
        }
    }
}
