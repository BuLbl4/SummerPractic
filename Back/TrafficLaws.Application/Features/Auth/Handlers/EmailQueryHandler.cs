using System.Net;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Auth.Queries;
using TrafficLaws.Application.Interfaces;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Auth;

namespace TrafficLaws.Application.Features.Auth.Handlers;

public class EmailQueryHandler : IRequestHandler<EmailConfirmQuery, EmailConfirmResponse>
{
    private readonly IEmailService _emailService;

    private readonly IUserRepository _userRepository;

    private readonly UserManager<User> _userManager;

    public EmailQueryHandler(IEmailService emailService,
        IUserRepository userRepository,
        UserManager<User> userManager)
    {
        _emailService = emailService;
        _userRepository = userRepository;
        _userManager = userManager;
    }
    public async Task<EmailConfirmResponse> Handle(EmailConfirmQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetById(Guid.Parse(request.UserId),cancellationToken);
        
        if (user == null)
        {
            return new EmailConfirmResponse
            {
                IsSuccessfully = false,
                Errors = new List<string> { "Такой пользователь не найден" }
            };
        }
       

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        
        string confirmationLink =
            $"http://localhost:5009/EmailConfirm?userId={user.Id}&token={WebUtility.UrlEncode(code)}";

        await _emailService.SendEmailAsync(user.Email!, "Подтверждение почты",
            $"Для подтверждения вашей электронной почты перейдите по <a href=\"{confirmationLink}\">ссылке</a>");

        return new EmailConfirmResponse
        {
            IsSuccessfully = true,
            Errors = null!
        };
    }
}