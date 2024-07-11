using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Result.DTO;
using TrafficLaws.Application.Features.Result.Query;

namespace TrafficLaws.Controllers;
[ApiController]
[Route("[controller]")]
public class ResultController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResultController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Зафиксировать результат теста
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Submit(SubmitRequest request, CancellationToken cancellationToken)
    {
        var res = await _mediator.Send(new SubmitResultQuery(request), cancellationToken);

        if (res.IsSuccessfully)
            return Ok(res);

        return BadRequest(res);
    }

    /// <summary>
    /// Проверить ответ на вопрос
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> CheckAnswer(CheckAnswerRequest request, CancellationToken cancellationToken)
    {
        var res = await _mediator.Send(new CheckAnswerQuery(request), cancellationToken);

        if (res.IsSuccessfully)
            return Ok(res);

        return BadRequest(res);
    }
    
    
    /// <summary>
    /// Добавить ответ на вопрос
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> AddUserAnswers([FromBody] UserAnswerRequest request, CancellationToken cancellationToken)
    {
        var res = await _mediator.Send(new AddUserAnswersQuery(request), cancellationToken);

        if (res.IsSuccessfully)
            return Ok(res);

        return BadRequest(res);
    }
    
    /// <summary>
    /// Проверить вопрос с несколькими вариантами ответа
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> CheckMultipleAnswers([FromBody] CheckMultipleAnswersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new CheckMultipleAnswersQuery(request), cancellationToken);

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
    /// Получить результаты пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserResult([FromQuery] GetUserResultRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new GetUserResultQuery(request), cancellationToken);

            if (res.IsSuccessfully)
                return Ok(res);

            return NotFound(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}