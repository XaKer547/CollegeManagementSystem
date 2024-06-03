using CollegeManagementSystem.Domain.Groups;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Groups;

public sealed record DeleteGroupCommand : IRequest
{
    public GroupId GroupId { get; init; }
}
