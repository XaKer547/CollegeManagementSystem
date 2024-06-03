using CollegeManagementSystem.Domain.Disciplines.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineDeletedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<DisciplineDeletedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(DisciplineDeletedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IDisciplineDeleted>(new
        {
            Id = notification.DisciplineId.Value,
        }, cancellationToken);
    }
}
