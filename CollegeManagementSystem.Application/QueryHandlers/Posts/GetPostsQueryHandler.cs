using CollegeManagementSystem.Application.Queries.Posts;
using CollegeManagementSystem.Domain.Helpers;
using MediatR;
using SharedKernel.DTOs.Posts;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Application.QueryHandlers.Posts;

public sealed class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IReadOnlyCollection<PostDTO>>
{
    public Task<IReadOnlyCollection<PostDTO>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<PostDTO> posts = [..Enum.GetValues<Roles>()
            .Select(r => new PostDTO
            {
                Id = (int)r,
                Name = r.GetDisplayName()!
            })];

        return Task.FromResult(posts);
    }
}
