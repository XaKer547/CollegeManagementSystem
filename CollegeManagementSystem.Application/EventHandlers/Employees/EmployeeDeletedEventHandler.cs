using CollegeManagementSystem.Domain.Employees.Events;
using CollegeManagementSystem.Domain.Services;
using MassTransit;
using MediatR;
using SmartCollege.RabbitMQ.Contracts.Users;

namespace CollegeManagementSystem.Application.EventHandlers.Employees;

public sealed class EmployeeDeletedEventHandler(IPublishEndpoint publishEndpoint) : INotificationHandler<EmployeeDeletedEvent>
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task Handle(EmployeeDeletedEvent notification, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish<IUserDeleted>(new
        {
            notification.Id
        }, cancellationToken);
    }
}