using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel;

public abstract class Entity<TEntityId> : Entity
    where TEntityId : EntityId
{
    public TEntityId Id { get; protected set; }
}

public abstract class Entity
{
    public bool Deleted { get; protected set; } = false;

    private readonly List<IDomainEvent> _events = [];
    protected void AddEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);
    public bool ContainsEvents() => _events.Count != 0;

    [NotMapped]
    public IDomainEvent[] Events => [.. _events];
}
