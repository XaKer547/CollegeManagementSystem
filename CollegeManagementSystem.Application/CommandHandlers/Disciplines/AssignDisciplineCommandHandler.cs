using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Domain.Services;
using FluentValidation;
using MediatR;

namespace CollegeManagementSystem.Application.CommandHandlers.Disciplines;

public class AssignDisciplineCommandHandler(IUnitOfWork unitOfWork, IValidator<AssignDisciplineCommand> validator) : IRequestHandler<AssignDisciplineCommand>
{
    public async Task Handle(AssignDisciplineCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

    }
}
