using CollegeManagementSystem.Application.Queries.Groups;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Groups;

namespace CollegeManagementSystem.Application.QueryHandlers.Groups;

public sealed class GetGroupsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetGroupsQuery, IReadOnlyCollection<GroupDTO>>
{
    public Task<IReadOnlyCollection<GroupDTO>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<GroupDTO> groups = [.. unitOfWork.Repository.Groups.Select(g => new GroupDTO
        {
            Id = g.Id.Value,
            SpecializationId = g.Specialization.Id.Value,
            Name = g.Name,
        })];

        return Task.FromResult(groups);
    }
}
