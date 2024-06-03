using CollegeManagementSystem.Domain.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Specializations;

public sealed record UpdateSpecializationCommand : IRequest
{
    public SpecializationId SpecializationId { get; init; }
    public string Name { get; init; }
}
