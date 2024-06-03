using CollegeManagementSystem.Application.Queries.Employees;
using CollegeManagementSystem.Domain.Helpers;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Employees;
using SharedKernel.DTOs.Posts;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Application.QueryHandlers.Employees;

public sealed class GetEmployeesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetEmployeesQuery, IReadOnlyCollection<EmployeeDTO>>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IReadOnlyCollection<EmployeeDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = unitOfWork.Repository.Employees.Select(e => new EmployeeDTO
        {
            Id = e.Id.Value,
            FirstName = e.FirstName,
            MiddleName = e.MiddleName,
            LastName = e.LastName,
            Posts = e.Roles.MapFromEnum(),
            Blocked = e.Blocked,
        }).ToArray();

        return employees;
    }
}

internal static class RoleExtenstions
{
    public static IReadOnlyCollection<PostDTO> MapFromEnum(this Roles[] roles)
    {
        return roles.Select(x => new PostDTO
        {
            Id = (int)x,
            Name = x.GetDisplayName()!
        })
            .ToArray();
    }
}