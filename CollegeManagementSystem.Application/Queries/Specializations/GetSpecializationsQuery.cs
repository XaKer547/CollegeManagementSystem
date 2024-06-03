using MediatR;
using SharedKernel.DTOs.Specializations;

namespace CollegeManagementSystem.Application.Queries.Specializations;

public sealed record GetSpecializationsQuery : IRequest<IReadOnlyCollection<SpecializationDTO>>
{

}
