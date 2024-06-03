using CollegeManagementSystem.Domain.Disciplines.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace CollegeManagementSystem.Application.EventHandlers.Disciplines;

public sealed class DisciplineCreatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<DisciplineCreatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(DisciplineCreatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IDisciplineCreated>(new
        {
            Id = notification.Discipline.Id.Value,
            notification.Discipline.Name,
        }, cancellationToken);
    }
}