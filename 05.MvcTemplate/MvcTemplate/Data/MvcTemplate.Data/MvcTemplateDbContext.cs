namespace MvcTemplate.Data
{
    using System;
    using System.Data.Entity.Infrastructure;

    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class MvcTemplateDbContext : IdentityDbContext<User>, IMvcTemplateDbContext, IDisposable, IObjectContextAdapter
    {
        public MvcTemplateDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    }
}
