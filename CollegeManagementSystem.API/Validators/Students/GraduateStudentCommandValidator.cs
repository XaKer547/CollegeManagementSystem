using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Students;

public class GraduateStudentCommandValidator : AbstractValidator<GraduateStudentCommand>
{
    public GraduateStudentCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.StudentId)
            .Exists(context);

        RuleFor(x => x.Graduated)
            .NotEmpty();
    }
}
