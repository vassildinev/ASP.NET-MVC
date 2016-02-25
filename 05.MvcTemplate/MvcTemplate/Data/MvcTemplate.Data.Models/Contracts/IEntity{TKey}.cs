namespace MvcTemplate.Data.Models.Contracts
{
    public interface IEntity<TKey> : IAuditInfo, IDeletableEntity
    {
        TKey Id { get; set; }
    }
}