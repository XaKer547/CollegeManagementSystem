namespace SharedKernel;

public abstract class EntityId
{
    public EntityId(Guid id) => Value = id;
    public EntityId() => Value = Guid.NewGuid();
    public Guid Value { get; private set; }

    public static explicit operator Guid(EntityId id) => id.Value;
}