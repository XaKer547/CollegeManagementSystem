using MediatR;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.Queries.Groups;

public sealed record GetGroupsQuery : IRequest<IReadOnlyCollection<GroupDTO>>
{
}
