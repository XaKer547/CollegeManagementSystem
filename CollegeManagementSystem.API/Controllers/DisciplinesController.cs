using CollegeManagementSystem.Application.Commands.Disciplines;
using CollegeManagementSystem.Application.Queries.Disciplines;
using CollegeManagementSystem.Domain.Disciplines;
using CollegeManagementSystem.Domain.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.DTOs.Disciplines;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DisciplinesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Добавить дисциплину
    /// </summary>
    /// <response code="201">Успешно создан</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление дисциплины</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateDiscipline(CreateDisciplineCommand createDiscipline)
    {
        var disciplineId = await mediator.Send(createDiscipline);

        return Created(string.Empty, disciplineId.Value);
    }

    /// <summary>
    /// Обновить дисциплину
    /// </summary>
    /// <param name="disciplineId">Идентификатор дисциплины</param>
    /// <param name="updateDiscipline"></param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение дисциплины</response>
    /// <response code="404">Дисциплина не найдена</response>
    [HttpPut("{disciplineId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateDiscipline(Guid disciplineId, UpdateDisciplineDTO updateDiscipline)
    {
        var command = new UpdateDisciplineCommand()
        {
            DisciplineId = new DisciplineId(disciplineId),
            Name = updateDiscipline.Name,
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Получить дисциплины
    /// </summary>
    /// <response code="200"></response>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<DisciplineDTO>))]
    public async Task<IActionResult> GetDisciplines()
    {
        var query = new GetDisciplinesQuery();

        var disciplines = await mediator.Send(query);

        return Ok(disciplines);
    }

    /// <summary>
    /// Удалить дисциплину
    /// </summary>
    /// <response code="204">Успешно удалена</response>
    /// <response code="403">Пользователь не имеет доступ на удаление дисциплины</response>
    /// <response code="404">Дисциплина не найдена</response>
    [HttpDelete("{disciplineId:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteDiscipline(Guid disciplineId)
    {
        var command = new DeleteDisciplineCommand()
        {
            DisciplineId = new DisciplineId(disciplineId)
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Связать дисциплину с преподавателем
    /// </summary>
    /// <param name="assignDiscipline"></param>
    /// <response code="204">Дисциплина успешно назначена</response>
    /// <response code="400">Сотрудник уже привязан к данной дисциплине</response>
    /// <response code="403">Пользователь не имеет доступ на назначение дисциплины преподавателю</response>
    /// <response code="404">Дисциплина или преподаватель не найден</response>
    [HttpPost("assign")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> AssingDiscipline(DisciplineAssignmentDTO assignDiscipline)
    {
        var command = new AssignDisciplineCommand()
        {
            DisciplineId = new DisciplineId(assignDiscipline.DisciplineId),
            EmployeeId = new EmployeeId(assignDiscipline.EmployeeId)
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Отвязать дисциплину от преподавателя
    /// </summary>
    /// <param name="unAssignDiscipline"></param>
    /// <response code="204">Дисциплина успешно снята</response>
    /// <response code="400">Сотрудник не привязан к данной дисциплине</response>
    /// <response code="403">Пользователь не имеет доступ на снятие дисциплины преподавателю</response>
    /// <response code="404">Дисциплина или преподаватель не найден</response>
    [HttpPost("unassign")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UnAssignDiscipline(DisciplineAssignmentDTO unAssignDiscipline)
    {
        var command = new AssignDisciplineCommand()
        {
            DisciplineId = new DisciplineId(unAssignDiscipline.DisciplineId),
            EmployeeId = new EmployeeId(unAssignDiscipline.EmployeeId)
        };

        await mediator.Send(command);

        return NoContent();
    }
}