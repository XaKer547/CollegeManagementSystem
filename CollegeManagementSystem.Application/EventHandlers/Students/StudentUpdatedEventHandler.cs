using CollegeManagementSystem.Domain.Students.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace CollegeManagementSystem.Application.EventHandlers.Students;

public sealed class StudentUpdatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<StudentUpdatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(StudentUpdatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IStudentUpdated>(new
        {
            notification.Student.Id,
            notification.Student.FirstName,
            notification.Student.MiddleName,
            notification.Student.LastName,
            GroupId = notification.Student.Group?.Id,
        }, cancellationToken);
    }
}
