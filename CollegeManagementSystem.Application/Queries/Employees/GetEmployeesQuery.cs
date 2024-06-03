using MediatR;
using SharedKernel.DTOs.Employees;

namespace CollegeManagementSystem.Application.Queries.Employees;

public sealed record GetEmployeesQuery : IRequest<IReadOnlyCollection<EmployeeDTO>>
{

}
