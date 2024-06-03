using CollegeManagementSystem.Domain.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Employees;

public sealed record DeleteEmployeeCommand : IRequest
{
    public EmployeeId EmployeeId { get; init; }
}
