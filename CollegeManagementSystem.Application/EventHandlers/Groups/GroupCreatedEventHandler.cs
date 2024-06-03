using CollegeManagementSystem.Domain.Groups.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace CollegeManagementSystem.Application.EventHandlers.Groups;

public sealed class GroupCreatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<GroupCreatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(GroupCreatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IGroupCreated>(new
        {
            notification.Group.Id,
            notification.Group.Name,
        }, cancellationToken);
    }
}
