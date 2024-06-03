using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Groups;

public sealed record UpdateGroupCommand : IRequest
{
    public GroupId GroupId { get; init; }
    public string Name { get; init; }
    public SpecializationId SpecializationId { get; init; }
}
