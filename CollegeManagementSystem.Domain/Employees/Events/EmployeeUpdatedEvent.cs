using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed record EmployeeUpdatedEvent : IDomainEvent
{
    public EmployeeUpdatedEvent(Employee employee)
    {
        Employee = employee;
    }

    public Employee Employee { get; init; }
}
