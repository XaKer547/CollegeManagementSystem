using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Groups;

public sealed record CreateGroupCommand : IRequest<GroupId>
{
    public string Name { get; init; }
    public SpecializationId SpecializationId { get; init; }
}
