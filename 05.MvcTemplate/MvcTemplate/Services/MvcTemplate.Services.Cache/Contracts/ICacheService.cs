namespace MvcTemplate.Services.Cache.Contracts
{
    using System;

    public interface ICacheService
    {
        TEntity Get<TEntity>(string itemName, Func<TEntity> getDataFunc, int durationInSeconds);

        void Remove(string itemName);
    }
}
