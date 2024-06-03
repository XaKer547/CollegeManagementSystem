using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Queries.Employees;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Employees;

public class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
{
    public GetEmployeeQueryValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.EmployeeId)
            .Exists(context);
    }
}