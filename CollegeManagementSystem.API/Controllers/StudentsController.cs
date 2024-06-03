using CollegeManagementSystem.Application.Commands.Students;
using CollegeManagementSystem.Application.Queries.Students;
using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.DTOs.Students;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Обновить студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента</param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение студента</response>
    /// <response code="404">Студент не найден</response>
    [HttpPatch("{studentId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateStudent(Guid studentId, UpdateStudentDTO updateStudent)
    {
        var command = new UpdateStudentCommand()
        {
            StudentId = new StudentId(studentId),
            GroupId = new GroupId(updateStudent.GroupId),
            FirstName = updateStudent.Firstname,
            MiddleName = updateStudent.Middlename,
            LastName = updateStudent.Lastname,
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Получить студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента</param>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение студента</response>
    /// <response code="404">Студент не найден</response>
    [HttpGet("{studentId}")]
    [ProducesResponseType(200, Type = typeof(StudentDTO))]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetStudent(Guid studentId)
    {
        var query = new GetStudentQuery()
        {
            StudentId = new StudentId(studentId)
        };

        var student = await mediator.Send(query);

        return Ok(student);
    }

    /// <summary>
    /// Удалить студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента</param>
    /// <response code="204">Студент удален</response>
    /// <response code="403">Пользователь не имеет доступ на удаление студента</response>
    /// <response code="404">Студент не найден</response>
    [HttpDelete("{studentId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        var command = new DeleteStudentCommand()
        {
            StudentId = new StudentId(studentId)
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Сделать студента выпускником
    /// </summary>
    /// <param name="studentId">Идентификатор студента</param>
    /// <param name="graduated">Будет ли он выпускником</param>
    /// <response code="204">Cтатус студента обновлен</response>
    /// <response code="403">Пользователь не имеет доступ на перевод в выпускники</response>
    /// <response code="404">Студент не найден</response>
    /// <response code="409">Дипломная работа студента не закрыты</response>
    [HttpPatch("{studentId}/Graduate")]
    [ProducesResponseType(204)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    public async Task<IActionResult> GraduateStudent(Guid studentId, [FromBody] bool? graduated = default)
    {
        var command = new GraduateStudentCommand()
        {
            StudentId = new StudentId(studentId),
            Graduated = graduated ?? true
        };

        await mediator.Send(command);

        return NoContent();
    }
}