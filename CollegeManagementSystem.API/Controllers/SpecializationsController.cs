using CollegeManagementSystem.Application.Commands.Specializations;
using CollegeManagementSystem.Application.Queries.Specializations;
using CollegeManagementSystem.Domain.Specializations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.DTOs.Specializations;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SpecializationsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Добавить специализацию
    /// </summary>
    /// <response code="201">Успешно создана</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление специализации</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateSpecialization(CreateSpecializationCommand createSpecialization)
    {
        var specializationId = await mediator.Send(createSpecialization);

        return Created(string.Empty, specializationId.Value);
    }

    /// <summary>
    /// Обновить специализацию
    /// </summary>
    /// <param name="specializationId">Идентификатор специализации</param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение специализации</response>
    /// <response code="404">Специализация не найдена</response>
    [HttpPut("{specializationId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateSpecialization(Guid specializationId, UpdateSpecializationDTO updateSpecialization)
    {
        var command = new UpdateSpecializationCommand()
        {
            SpecializationId = new SpecializationId(specializationId),
            Name = updateSpecialization.Name,
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Получить специализации
    /// </summary>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение списка специализаций</response>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<SpecializationDTO>))]
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetSpecializations()
    {
        var query = new GetSpecializationsQuery();

        var specialization = await mediator.Send(query);

        return Ok(specialization);
    }

    /// <summary>
    /// Удалить специализацию
    /// </summary>
    /// <param name="specializationId">Идентификатор специализации</param>
    /// <response code="204">Специализация удалена</response>
    /// <response code="403">Пользователь не имеет доступ на удаление специализации</response>
    /// <response code="404">специализация не найдена</response>
    [HttpDelete("{specializationId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSpecialization(Guid specializationId)
    {
        var command = new DeleteSpecializationCommand()
        {
            SpecializationId = new SpecializationId(specializationId)
        };

        await mediator.Send(command);

        return NoContent();
    }
}
