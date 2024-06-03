using CollegeManagementSystem.Application.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.DTOs.Posts;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PostsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Получить список должностей
    /// </summary>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение списка должностей</response>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<PostDTO>))] 
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetPosts()
    {
        var query = new GetPostsQuery();

        var posts = await mediator.Send(query);

        return Ok(posts);
    }
}
