using CollegeManagementSystem.Domain.Groups.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace CollegeManagementSystem.Application.EventHandlers.Groups;

public sealed class GroupDeletedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<GroupDeletedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(GroupDeletedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IGroupDeleted>(new
        {
            Id = notification.GroupId,
        }, cancellationToken);
    }
}
