using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Specializations;

public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateSpecializationCommand>
{
    public UpdateSpecializationCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.SpecializationId)
            .Exists(context);
    }
}
