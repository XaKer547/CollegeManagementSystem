using CollegeManagementSystem.Domain.Disciplines.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineUpdatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<DisciplineUpdatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(DisciplineUpdatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IDisciplineUpdated>(new
        {
            Id = notification.Discipline.Id.Value,
            notification.Discipline.Name,
        }, cancellationToken);
    }
}
