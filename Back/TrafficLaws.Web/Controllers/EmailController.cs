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

    [HttpPost("[action]")]
    public async Task<IActionResult> SendEmail(string email, CancellationToken cancellationToken)
    {
        await _emailService.SendEmailAsync(email, "", "Hello");

        return Ok();
    }

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