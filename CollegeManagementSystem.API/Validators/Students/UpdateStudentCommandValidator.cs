using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator(CollegeManagementSystemDbContext context)
    {
        RuleFor(x => x.StudentId)
            .Exists(context);

        When(x => x.GroupId is not null, () =>
        {
            RuleFor(x => x.GroupId!)
            .Exists(context);
        });
    }
}