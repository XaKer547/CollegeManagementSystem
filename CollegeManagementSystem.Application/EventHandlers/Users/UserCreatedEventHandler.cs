using CollegeManagementSystem.Domain.Users.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Users;

public sealed class UserCreatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<UserCreatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IUserCreated>(new
        {
            notification.Email,
            notification.Password,
            notification.Roles,
        }, cancellationToken);
    }
}