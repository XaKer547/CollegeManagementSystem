using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Specializations;

public sealed class UpdateSpecializationComandHandler(IUnitOfWork unitOfWork, IValidator<UpdateSpecializationCommand> validator) : IRequestHandler<UpdateSpecializationCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateSpecializationCommand> validator = validator;

    public async Task Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var specialization = unitOfWork.Repository.Specializations.Single(s => s.Id == request.SpecializationId);

        specialization.Update(request.Name);

        unitOfWork.Repository.UpdateEntity(specialization);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
