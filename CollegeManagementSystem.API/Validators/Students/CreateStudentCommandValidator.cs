using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Students;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.MiddleName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.GroupId)
            .Exists(context);
    }
}