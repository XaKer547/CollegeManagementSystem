using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Groups;

public sealed class DeleteGroupCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteGroupCommand> validator) : IRequestHandler<DeleteGroupCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteGroupCommand> validator = validator;

    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var group = unitOfWork.Repository.Groups.Single(g => g.Id == request.GroupId);
        
        group.Delete();

        unitOfWork.Repository.DeleteEntity(group);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
