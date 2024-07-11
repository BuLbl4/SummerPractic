using System.Security.Claims;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Auth.Queries;
using TrafficLaws.Application.Interfaces;
using TrafficLaws.Application.Responses;


namespace TrafficLaws.Application.Features.Auth.Handlers;

public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordQuery, BaseResponse>
{
    private readonly IEmailService _emailService;
    private readonly UserManager<User> _userManager;

    public ForgotPasswordHandler(IEmailService emailService,
        UserManager<User> userManager)
    {
        _emailService = emailService;
        _userManager = userManager;
    }
    public async Task<BaseResponse> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
    {
        var users = await _userManager.FindByEmailAsync(request.Email);

        if (users == null)
            return new BaseResponse { Errors = new List<string> { "User not found" } };
        
        var code = GenerateRandomCode();
        await _userManager.AddClaimAsync(users, new Claim("ResetPasswordCode", code));
        await _emailService.SendEmailAsync(request.Email, 
            "Reset Password", $"Никому не сообщайте этот код! <br/> code: {code}");
        
        return new BaseResponse
        {
            IsSuccessfully = true,
            Message = code
        };
    }

    private string GenerateRandomCode() => new Random().Next(100000, 999999).ToString();
}