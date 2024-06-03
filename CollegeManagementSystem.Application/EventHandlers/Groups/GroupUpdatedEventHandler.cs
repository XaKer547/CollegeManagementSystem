using CollegeManagementSystem.Domain.Groups.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace CollegeManagementSystem.Application.EventHandlers.Groups;

public sealed class GroupUpdatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<GroupUpdatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(GroupUpdatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IGroupUpdated>(new
        {
            notification.Group.Id,
            notification.Group.Name,
        }, cancellationToken);
    }
}
