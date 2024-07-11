using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Features.Auth.Queries;


namespace TrafficLaws.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly SignInManager<User> _signInManager;

    public AuthController(IMediator mediator, SignInManager<User> signInManager)
    {
        _mediator = mediator;
        _signInManager = signInManager;
    }
    /// <summary>
    /// Аутентифицироваться
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Authentication(AuthRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _mediator.Send(new AuthQuery(request), cancellationToken);

            if (!result.IsSuccessfully)
            {
                return BadRequest(result.Errors);
            }

            var cookieOptions = new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                Expires = DateTime.Now.AddHours(2)
            };

            Response.Cookies.Append("authCookie", result.Token, cookieOptions);

            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, $"Internal Server Error: {e.Message}");
        }
    }

    
    /// <summary>
    /// Функция забыли пароль
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new ForgotPasswordQuery(request), cancellationToken);

            if (res.IsSuccessfully)
            {
                return Ok(res);
            }

            return BadRequest(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, $"Internal Server Error: {e.Message}");
        }
    }

    /// <summary>
    /// Проверка кода с почты
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> CodeCheck(CodeCheckRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new CodeCheckQuery(request), cancellationToken);

            if (res.IsSuccessfully)
            {
                return Ok(res);
            }


            return BadRequest(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, $"Internal Server Error: {e.Message}");
        }
    }

    
    /// <summary>
    /// Обновить пароль
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var res = await _mediator.Send(new ResetPasswordQuery(request), cancellationToken);

            if (res.IsSuccessfully)
            {
                return Ok(res);
            }

            return BadRequest(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, $"Internal Server Error: {e.Message}");
        }
    }

    /// <summary>
    /// Выйти с аккаунта
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> LogOut()
    {
        try
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Append(
                "authCookie", "",
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddDays(-1)
                });

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, $"Internal Server Error: {e.Message}");
        }
    }
}