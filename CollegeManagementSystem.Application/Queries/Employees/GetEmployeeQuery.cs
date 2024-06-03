using CollegeManagementSystem.Domain.Employees;
using MediatR;
using SharedKernel.DTOs.Employees;

namespace CollegeManagementSystem.Application.Queries.Employees;

public sealed record GetEmployeeQuery : IRequest<EmployeeDTO>
{
    public EmployeeId EmployeeId { get; init; }
}
