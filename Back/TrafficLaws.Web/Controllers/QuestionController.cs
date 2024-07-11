using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Question.DTO;
using TrafficLaws.Application.Features.Question.Queries;

namespace TrafficLaws.Controllers;
[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Добавить вопрос
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> AddQuestion(AddQuestionRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new AddQuestionsQuery(request), cancellationToken);
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
    /// Добавить вопрос и ответы к нему
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateQuestionAndAnswer([FromBody] CreateQuestionAndAnswerRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new CreateQuestionAndAnswerQuery(request), cancellationToken);
            if (res.IsSuccessfully)
                return Ok(res);

            return Forbid();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Forbid();
        }
    }
}