using MediatR;
using SharedKernel;

namespace CollegeManagementSystem.Infrastucture.EventDispatcher;

public sealed class CollegeManagementSystemEventDispatcher(IMediator mediator) : IDomainEventDispatcher
{
    private readonly IMediator _mediator = mediator;
    public async Task DispatchAsync(IDomainEvent @event)
    {
        await _mediator.Publish(@event);
    }
}
