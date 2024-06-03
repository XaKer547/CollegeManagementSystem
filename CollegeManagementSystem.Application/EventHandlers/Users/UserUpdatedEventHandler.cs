using CollegeManagementSystem.Domain.Users.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Users;

public sealed class UserUpdatedEventhandler(IPublishEndpoint publishEndpoint) : INotificationHandler<UserUpdatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IUserUpdated>(new
        {
            notification.Email,
            notification.Password,
            notification.Blocked,
            notification.Roles,
        }, cancellationToken);
    }
}