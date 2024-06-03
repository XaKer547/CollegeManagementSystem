using CollegeManagementSystem.Application.Commands.Users;
using CollegeManagementSystem.Domain.Students;
using CollegeManagementSystem.Domain.Users;
using CollegeManagementSystem.Infrastucture.Common;
using FluentValidation;

namespace CollegeManagementSystem.API.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(CollegeManagementSystemDbContext context)
    {
    
    }
}