using CollegeManagementSystem.Domain.Disciplines;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Disciplines;

public sealed record DeleteDisciplineCommand : IRequest
{
    public DisciplineId DisciplineId { get; init; }
}
