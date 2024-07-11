using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Profile.DTO;
using TrafficLaws.Application.Features.Profile.Queries;

namespace TrafficLaws.Controllers;
[ApiController]
[Route("[controller]")]
public class EditProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить пользователя по id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new GetUserQuery(request), cancellationToken);

            if (res.IsSuccessfully)
                return Ok(res);

            return BadRequest(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    /// <summary>
    /// Поменять пароль
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> EditPassword(EditPasswordRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new EditPasswordQuery(request), cancellationToken);

            if (res.IsSuccessfully)
            {
                return Ok(res);
            }

            return BadRequest(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}