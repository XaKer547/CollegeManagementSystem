using CollegeManagementSystem.Domain.Specializations.Events;
using MassTransit;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Specializations;

public sealed class SpecializationCreatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<SpecializationCreatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(SpecializationCreatedEvent notification, CancellationToken cancellationToken)
    {
        //await publishEndpoint.Publish<ISpecia>(cancellationToken);
    }
}
