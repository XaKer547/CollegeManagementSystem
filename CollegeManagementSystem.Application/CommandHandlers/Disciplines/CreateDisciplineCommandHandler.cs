using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public class CreateDisciplineCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateDisciplineCommand> validator) : IRequestHandler<CreateDisciplineCommand, DisciplineId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<CreateDisciplineCommand> validator = validator;

    public async Task<DisciplineId> Handle(CreateDisciplineCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var discipline = Discipline.Create(request.Name);

        unitOfWork.Repository.AddEntity(discipline);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return discipline.Id;
    }
}
