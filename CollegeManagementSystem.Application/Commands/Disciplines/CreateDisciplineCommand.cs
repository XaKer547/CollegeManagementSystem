using CollegeManagementSystem.Domain.Disciplines;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Disciplines;

public sealed record CreateDisciplineCommand : IRequest<DisciplineId>
{
    public string Name { get; init; }
}
