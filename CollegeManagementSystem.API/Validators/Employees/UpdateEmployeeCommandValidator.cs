using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Employees;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.EmployeeId)
           .Exists(context);
    }
}
