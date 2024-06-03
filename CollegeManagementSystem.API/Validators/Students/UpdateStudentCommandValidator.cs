using CollegeManagementSystem.API.Helpers;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator(CollegeManagementSystemDbContext context)
    {
        When(x => x.GroupId?.Value != Guid.Empty, () =>
        {
            RuleFor(x => x.GroupId!)
            .Exists(context);
        });
    }
}