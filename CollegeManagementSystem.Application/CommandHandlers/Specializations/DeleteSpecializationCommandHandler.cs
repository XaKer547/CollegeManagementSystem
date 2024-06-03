using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class DeleteSpecializationCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteSpecializationCommand> validator) : IRequestHandler<DeleteSpecializationCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteSpecializationCommand> validator = validator;

    public async Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var specialization = unitOfWork.Repository.Specializations.Single(s => s.Id == request.SpecializationId);

        specialization.Delete();

        unitOfWork.Repository.DeleteEntity(specialization);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
