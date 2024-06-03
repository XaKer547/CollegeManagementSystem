using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public sealed record UpdateDisciplineCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateDisciplineCommand> validator) : IRequestHandler<UpdateDisciplineCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateDisciplineCommand> validator = validator;

    public async Task Handle(UpdateDisciplineCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var discipline = unitOfWork.Repository.Disciplines.Single(d => d.Id == request.DisciplineId);

        discipline.Update(request.Name);

        unitOfWork.Repository.UpdateEntity(discipline);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}