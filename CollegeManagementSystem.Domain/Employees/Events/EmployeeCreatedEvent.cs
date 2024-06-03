using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed class EmployeeCreatedEvent : IDomainEvent
{
    public EmployeeCreatedEvent(Employee employee)
    {
        Employee = employee;
    }

    public Employee Employee { get; init; }
}
