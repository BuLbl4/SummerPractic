using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Test.DTO;
using TrafficLaws.Application.Features.Test.Queries;

namespace TrafficLaws.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator )
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Получить все тесты
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllTests(CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new GetAllTestsQuery(), cancellationToken);
            Console.WriteLine(res);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    /// <summary>
    /// Создать тест
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateTest(CreateTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new CreateTestQuery(request), cancellationToken);
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
    /// Получить рандомный тест
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<IActionResult> GetRandomTest(CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new GetRandomTestQuery(), cancellationToken);
        
            if(res.IsSuccessfully)
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
    /// Получить тест по id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<IActionResult> GetTestById([FromQuery] GetTestByIdRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new GetTestByIdQuery(request), cancellationToken);

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
    
    /// <summary>
    /// Создать тест от пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateUserTest(CreateUserTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new CreateUserTestQuery(request), cancellationToken);
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
    
}