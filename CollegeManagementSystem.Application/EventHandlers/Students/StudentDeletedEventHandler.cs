using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Students.Events;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace CollegeManagementSystem.Application.EventHandlers.Students;

public sealed class StudentDeletedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<StudentDeletedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(StudentDeletedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IStudentDeleted>(new
        {
            Id = notification.Id,
        }, cancellationToken);
    }
}
