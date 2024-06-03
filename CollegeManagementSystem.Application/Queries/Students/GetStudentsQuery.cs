using CollegeManagementSystem.Domain.Groups;
using MediatR;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.Application.Queries.Students;

public sealed record GetStudentsQuery : IRequest<IReadOnlyCollection<StudentDTO>>
{
    public GroupId GroupId { get; init; }
}
