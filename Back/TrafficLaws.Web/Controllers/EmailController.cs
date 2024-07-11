using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Profile.DTO;
using TrafficLaws.Application.Features.Profile.Queries;
using TrafficLaws.Application.Interfaces;

namespace TrafficLaws.Controllers;
[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly IMediator _mediator;

    public EmailController(IEmailService emailService, IMediator mediator)
    {
        _emailService = emailService;
        _mediator = mediator;
    }
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> SendEmail(string email, string message, CancellationToken cancellationToken)
    {
        await _emailService.SendEmailAsync(email, "", message);

        return Ok();
    }
    /// <summary>
    /// Подтверждение почты
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> ConfirmEmailFromCode(ConfirmEmailRequest request,
        CancellationToken cancellationToken)
    {
        var res = await _mediator.Send(new ConfirmEmailQuery(request), cancellationToken);

        if (res.IsSuccessfully)
            return Ok(res);

        return NotFound(res);
    }
}