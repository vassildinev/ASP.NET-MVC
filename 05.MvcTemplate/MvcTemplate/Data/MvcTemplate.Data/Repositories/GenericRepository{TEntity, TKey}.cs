namespace MvcTemplate.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Contracts;
    using Data.Contracts;
    using Models.Contracts;

    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>, IDisposable
        where TEntity : class, IEntity<TKey>
    {
        private readonly IMvcTemplateDbContext context;
        private readonly IDbSet<TEntity> set;

        public GenericRepository(IMvcTemplateDbContext context)
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
            return this.set.Where(entity => !entity.IsDeleted);
        }

        public IQueryable<TEntity> AllWithDeleted()
        {
            return this.set;
        }

        public TEntity Attach(TEntity entity)
        {
            this.set.Attach(entity);
            return entity;
        }

        public void Delete(TKey id)
        {
            TEntity entity = this.GetById(id);
            this.Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            this.Update(entity);
        }

        public void HardDelete(TKey id)
        {
            TEntity entity = this.GetById(id);
            if (entity != null)
            {
                this.set.Remove(entity);
            }
        }

        public void HardDelete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public void Detach(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public TEntity GetById(TKey id)
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

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
