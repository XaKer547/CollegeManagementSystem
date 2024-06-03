using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class UpdateDisciplineCommandValidator : AbstractValidator<UpdateDisciplineCommand>
{
    public UpdateDisciplineCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.DisciplineId)
            .Exists(context);
    }
}
