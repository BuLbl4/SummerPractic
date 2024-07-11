using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Auth.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Auth;

namespace TrafficLaws.Application.Features.Auth.Handlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResponse>
{
    private readonly IUserRepository _userRepository;
    
    private readonly SignInManager<User> _signInManager;

    private readonly UserManager<User> _userManager;

    private readonly IJwtService _jwt;

    public LoginQueryHandler(IUserRepository userRepository,
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IJwtService jwt)
    {
        _userRepository = userRepository;
        _signInManager = signInManager;
        _userManager = userManager;
        _jwt = jwt;
    }
    public async Task<AuthResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if(request == null)
            throw new ArgumentNullException(nameof(request));
        
        if (string.IsNullOrEmpty(request.Password))
            throw new ApplicationException("Password обязателен");

        var user = await _userRepository.GetByEmail(request.Email, cancellationToken);

        if (user == null)
        {
            return new AuthResponse
            {
                IsSuccessfully = false,
                Token = null!,
                Errors = new List<string> { "Такой пользователь не найден" }
            };
        }
        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
        {
            return new AuthResponse
            {
                IsSuccessfully = false,
                Token = null!,
                Errors = new List<string> { "Неверный пароль" }
            };
        }
        await _signInManager.SignInAsync(user, false);
        
        var token = _jwt.GenerateToken(user);
        
        return new AuthResponse
        {
            IsSuccessfully = true,
            Errors = null!,
            Token = token
        };
    }
}