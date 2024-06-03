using CollegeManagementSystem.Domain.Specializations;
using MediatR;

namespace CollegeManagementSystem.Application.Commands.Specializations;

public record CreateSpecializationCommand : IRequest<SpecializationId>
{
    public string Name { get; init; }
}
