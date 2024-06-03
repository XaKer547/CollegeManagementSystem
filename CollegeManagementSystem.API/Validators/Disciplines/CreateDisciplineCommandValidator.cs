using CollegeManagementSystem.Application.Commands.Disciplines;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Disciplines;

public class CreateDisciplineCommandValidator : AbstractValidator<CreateDisciplineCommand>
{
    public CreateDisciplineCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
