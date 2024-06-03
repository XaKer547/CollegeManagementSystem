using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Grops;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.SpecializationId)
            .Exists(context);
    }
}
