using CollegeManagementSystem.Application.Commands.Users;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Users;

public sealed class UpdateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateUserCommand> validator) : IRequestHandler<UpdateUserCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateUserCommand> validator = validator;

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        //var user = unitOfWork.Repository.GetUser(request.Email);

        //user.UpdateAccount(request.Password, request.Roles ?? user.Roles.ToArray(), request.Blocked ?? user.Blocked);

        //unitOfWork.Repository.UpdateEntity(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}