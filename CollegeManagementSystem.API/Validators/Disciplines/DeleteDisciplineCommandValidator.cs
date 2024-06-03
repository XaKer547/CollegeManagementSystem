using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class DeleteDisciplineCommandValidator : AbstractValidator<DeleteDisciplineCommand>
{
    public DeleteDisciplineCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.DisciplineId)
            .Exists(context);
    }
}