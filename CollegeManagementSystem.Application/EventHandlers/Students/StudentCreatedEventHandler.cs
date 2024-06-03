using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace CollegeManagementSystem.Application.EventHandlers.Students;

public sealed class StudentCreatedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<StudentCreatedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(StudentCreatedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IStudentCreated>(new
        {
            notification.Student.Id,
            notification.Student.FirstName,
            notification.Student.MiddleName,
            notification.Student.LastName,
            GroupId = notification.Student.Group.Id,
        }, cancellationToken);
    }
}
