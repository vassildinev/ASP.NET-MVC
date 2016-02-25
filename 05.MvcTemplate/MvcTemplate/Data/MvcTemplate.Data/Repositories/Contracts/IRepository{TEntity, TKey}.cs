namespace MvcTemplate.Data.Repositories.Contracts
{
    using System;
    using System.Linq;

    using Models.Contracts;

    public interface IRepository<TEntity, TKey> : IDisposable
        where TEntity : class, IEntity<TKey>
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> AllWithDeleted();

        TEntity GetById(TKey id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey id);

        void HardDelete(TEntity entity);

        void HardDelete(TKey id);

        TEntity Attach(TEntity entity);

        void Detach(TEntity entity);

        int SaveChanges();
    }
}
