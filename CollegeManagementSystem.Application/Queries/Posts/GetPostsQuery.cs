using MediatR;
using SharedKernel.DTOs.Posts;

namespace CollegeManagementSystem.Application.Queries.Posts;

public sealed record GetPostsQuery : IRequest<IReadOnlyCollection<PostDTO>>
{

}
