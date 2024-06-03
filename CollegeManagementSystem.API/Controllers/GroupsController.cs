using CollegeManagementSystem.Application.Commands.Groups;
using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Application.Queries.Groups;
using CollegeManagementSystem.Application.Queries.Students;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.DTOs.Groups;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class GroupsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Добавить студенческую группу
    /// </summary>
    /// <response code="201">Успешно создана</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление группы</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateGroup(CreateGroupDTO createGroup)
    {
        var command = new CreateGroupCommand()
        {
            Name = createGroup.Name,
            SpecializationId = new SpecializationId(createGroup.SpecializationId)
        };

        var groupId = await mediator.Send(command);

        return Created(string.Empty, groupId.Value);
    }

    /// <summary>
    /// Обновить группу
    /// </summary>
    /// <param name="groupId">Идентификатор группы</param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение группы</response>
    /// <response code="404">Группа не найдена</response>
    [HttpPut("{groupId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateGroup(Guid groupId, UpdateGroupDTO updateGroup)
    {
        var command = new UpdateGroupCommand()
        {
            GroupId = new GroupId(groupId),
            SpecializationId = new SpecializationId(updateGroup.SpecializationId),
            Name = updateGroup.Name,
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Получить студенческую группу
    /// </summary>
    /// <param name="groupId">Идентификатор группы</param>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение группы</response>
    /// <response code="404">Группа не найдена</response>
    [HttpGet("{groupId}")]
    [ProducesResponseType(200, Type = typeof(GroupDTO))]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetGroup(Guid groupId)
    {
        var query = new GetGroupQuery()
        {
            GroupId = new GroupId(groupId),
        };

        var group = await mediator.Send(query);

        return Ok(group);
    }

    /// <summary>
    /// Получить студенческие группы
    /// </summary>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение списка групп</response>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<GroupDTO>))]
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetGroups()
    {
        var query = new GetGroupsQuery();

        var groups = await mediator.Send(query);

        return Ok(groups);
    }

    /// <summary>
    /// Добавить студента
    /// </summary>
    /// <response code="201">Успешно создан</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление студента</response>
    [HttpPost("{groupId}/students")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateStudent(Guid groupId, CreateStudentDTO createStudent)
    {
        var command = new CreateStudentCommand()
        {
            GroupId = new GroupId(groupId),
            FirstName = createStudent.Firstname,
            MiddleName = createStudent.Middlename,
            LastName = createStudent.Lastname,
        };

        var studentId = await mediator.Send(command);

        return Created(string.Empty, studentId.Value);
    }

    /// <summary>
    /// Получить студентов группы
    /// </summary>
    /// <param name="groupId">Идентификатор группы</param>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение списка студентов в группе</response>
    [HttpGet("{groupId}/students")]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<StudentDTO>))]
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetGroupStudents(Guid groupId)
    {
        var query = new GetStudentsQuery()
        {
            GroupId = new GroupId(groupId)
        };

        var students = await mediator.Send(query);

        return Ok(students);
    }

    /// <summary>
    /// Удалить студенческую группу
    /// </summary>
    /// <param name="groupId">Идентификатор группы</param>
    /// <response code="204">Группа удалена</response>
    /// <response code="403">Пользователь не имеет доступ на удаление студенческой группы</response>
    /// <response code="404">Группа не найдена</response>
    [HttpDelete("{groupId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteGroup(Guid groupId)
    {
        var command = new DeleteGroupCommand()
        {
            GroupId = new GroupId(groupId)
        };

        await mediator.Send(command);

        return NoContent();
    }
}