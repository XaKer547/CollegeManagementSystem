using CollegeManagementSystem.Domain.Users.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Users;

public sealed class UserDeletedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<UserDeletedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IUserDeleted>(new
        {
            notification.Email,
        }, cancellationToken);
    }
}
