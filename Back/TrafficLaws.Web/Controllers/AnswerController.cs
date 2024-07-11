using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Answer.DTO;
using TrafficLaws.Application.Features.Answer.Queries;
using TrafficLaws.Application.Interfaces.Repository;

namespace TrafficLaws.Controllers;
[ApiController]
[Route("[controller]")]
public class AnswerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAnswerRepository _repository;

    public AnswerController(IMediator mediator, IAnswerRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> AddAnswers(AddAnswerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new AddAnswerQuery(request), cancellationToken);

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
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Seed(CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Seed(cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}