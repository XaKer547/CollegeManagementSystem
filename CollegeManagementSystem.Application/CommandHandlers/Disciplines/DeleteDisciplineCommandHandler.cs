using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public class DeleteDisciplineCommandHandler(IUnitOfWork unitOfWork,
    IValidator<DeleteDisciplineCommand> validator) : IRequestHandler<DeleteDisciplineCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteDisciplineCommand> validator = validator;

    public async Task Handle(DeleteDisciplineCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var discipline = unitOfWork.Repository.Disciplines.Single(d => d.Id == request.DisciplineId);

        discipline.Delete();

        unitOfWork.Repository.DeleteEntity(discipline);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}