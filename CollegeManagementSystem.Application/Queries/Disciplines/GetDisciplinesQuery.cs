using MediatR;
using SharedKernel.DTOs.Disciplines;

namespace CollegeManagementSystem.Application.Queries.Disciplines;

public sealed record GetDisciplinesQuery : IRequest<IReadOnlyCollection<DisciplineDTO>>
{
}
