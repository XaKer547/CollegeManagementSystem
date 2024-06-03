using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Domain.Specializations.Events;
using MediatR;

namespace CollegeManagementSystem.Application.EventHandlers.Specializations;

public sealed class SpecializationUpdatedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<SpecializationUpdatedEvent>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task Handle(SpecializationUpdatedEvent notification, CancellationToken cancellationToken)
    {

    }
}
