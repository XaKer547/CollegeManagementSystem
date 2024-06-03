using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class AssignDisciplineCommandValidator : AbstractValidator<AssignDisciplineCommand>
{
    public AssignDisciplineCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.DisciplineId)
            .Exists(context);

        RuleFor(x => x.EmployeeId)
            .Exists(context);
    }
}