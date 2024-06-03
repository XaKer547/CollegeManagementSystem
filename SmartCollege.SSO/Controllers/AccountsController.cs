using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCollege.SSO.Models.Commands;
using System.Security.Claims;

namespace SmartCollege.SSO.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Logup(CreateRepresentativeOfCompanyCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode,
            new
            {
                result.Description
            });
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode,
        new
        {
            result.Description
        });
    }

    [HttpPatch]
    [Authorize(Policy = "RepresentationRolePolicy")]
    public async Task<IActionResult> UpdateAccount(UpdateRepresentativeOfCompanyCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));

        var email = User.FindFirst(ClaimsIdentity.DefaultNameClaimType)!;
        
        var result = await _mediator.Send(new UpdateRepresentativeOfCompanyWithEmailCommand(email.Value, command));

        return StatusCode(result.StatusCode,
        new
        {
            result.Description
        });
    }
}