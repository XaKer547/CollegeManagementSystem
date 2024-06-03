using CollegeManagementSystem.Domain.Groups;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.Queries.Groups;

public sealed record GetGroupQuery : IRequest<GroupDTO>
{
    public GroupId GroupId { get; init; }
}
