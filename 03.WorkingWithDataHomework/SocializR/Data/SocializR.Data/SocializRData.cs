namespace SocializR.Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Repositories.Contracts;
    using Repositories;
    using Contracts;

    public class SocializRData : ISocializRData
    {
        private readonly ISocializRDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public SocializRData(ISocializRDbContext context)
        {
            this.repositories = new Dictionary<Type, object>();
            this.context = context;
        }

        public IRepository<User> UsersRepository
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Shout> ShoutsRepository
        {
            get { return this.GetRepository<Shout>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            Type repositoryType = typeof(TEntity);
            if (!this.repositories.ContainsKey(repositoryType))
            {
                var repository = new GenericRepository<TEntity>(this.context);
                this.repositories.Add(repositoryType, repository);
            }

            return (IRepository<TEntity>)this.repositories[repositoryType];
        }
    }
}
