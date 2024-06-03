using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed class EmployeeDeletedEvent : IDomainEvent
{
    public EmployeeDeletedEvent(EmployeeId id)
    {
        Id = id;
    }

    public EmployeeId Id { get; init; }
}
