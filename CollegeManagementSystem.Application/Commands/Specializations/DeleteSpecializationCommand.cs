using CollegeManagementSystem.Domain.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Specializations;

public sealed record DeleteSpecializationCommand : IRequest
{
    public SpecializationId SpecializationId { get; init; }
}
