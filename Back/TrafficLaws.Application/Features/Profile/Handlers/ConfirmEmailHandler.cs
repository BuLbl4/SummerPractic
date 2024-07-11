using System.Security.Claims;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Profile.Queries;
using TrafficLaws.Application.Interfaces;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Profile.Handlers;

public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailQuery, BaseResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;

    public ConfirmEmailHandler(UserManager<User> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
    }
    public async Task<BaseResponse> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return new BaseResponse { Errors = new List<string> { "User not found" } };

        var code = GenerateRandomCode();
        await _userManager.AddClaimAsync(user, new Claim("ConfirmEmailCode", code));
        await _emailService.SendEmailAsync(request.Email, 
            "Confirm Email", $"Никому не сообщайте этот код! <br/> code: {code}");
        
        return new BaseResponse
        {
            IsSuccessfully = true,
            Message = code
        };
        
    }
    
    private string GenerateRandomCode() => new Random().Next(100000, 999999).ToString();

}