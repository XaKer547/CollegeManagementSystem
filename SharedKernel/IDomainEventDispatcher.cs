
namespace SharedKernel;
public interface IDomainEventDispatcher
{
    Task DispatchAsync(IDomainEvent @event);
}
