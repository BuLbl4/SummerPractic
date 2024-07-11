using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Features.Auth.Queries;

namespace TrafficLaws.Controllers;
[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginRequest loginDtoRequest, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _mediator.Send(new LoginQuery(loginDtoRequest), cancellationToken);

            if (!result.IsSuccessfully)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}"); 
        }
    }
}