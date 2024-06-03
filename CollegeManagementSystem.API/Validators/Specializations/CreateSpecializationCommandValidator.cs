using CollegeManagementSystem.Application.Commands.Specializations;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Specializations;

public class CreateSpecializationCommandValidator : AbstractValidator<CreateSpecializationCommand>
{
    public CreateSpecializationCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
