using CollegeManagementSystem.Domain.Disciplines;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Disciplines;

public sealed record UpdateDisciplineCommand : IRequest
{
    public DisciplineId DisciplineId { get; init; }
    public string Name { get; init; }
}
