namespace SocializR.Data.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Contracts;
    using Data.Contracts;

    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ISocializRDbContext context;
        private readonly IDbSet<TEntity> set;

        public GenericRepository(ISocializRDbContext context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.set.Add(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.set;
        }

        public TEntity Attach(TEntity entity)
        {
            this.set.Attach(entity);
            return entity;
        }

        public void Delete(object id)
        {
            TEntity entity = this.GetById(id);
            if (entity != null)
            {
                this.set.Remove(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public void Detach(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public TEntity GetById(object id)
        {
            return this.set.Find(id);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
