using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Employees;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.EmployeeId)
            .Exists(context);
    }
}
