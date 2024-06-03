using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Disciplines;

public sealed record UnAssignDisciplineCommand : IRequest
{
    public DisciplineId DisciplineId { get; init; }
    public EmployeeId EmployeeId { get; init; }
}

