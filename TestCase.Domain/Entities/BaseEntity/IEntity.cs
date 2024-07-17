namespace TestCase.Domain.Entities.BaseEntity;

public interface IEntity<TId> where TId : IEquatable<TId>
{
    TId Id { get; }
}