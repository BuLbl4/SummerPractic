using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Auth.Queries;
using TrafficLaws.Application.Interfaces;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Auth;

namespace TrafficLaws.Application.Features.Auth.Handlers;

public class AuthQueryHandler : IRequestHandler<AuthQuery, AuthResponse>
{
    private readonly UserManager<User> _userManager;

    private readonly ILoginRepository _loginRepository;

    private readonly SignInManager<User> _signInManager;

    private readonly IJwtService _jwtService;
    
    private readonly IEmailService _emailService;

    public AuthQueryHandler(UserManager<User> userManager,
        ILoginRepository loginRepository,
        SignInManager<User> signInManager,
        IJwtService jwtService,
        IEmailService emailService)
    {
        _userManager = userManager;
        _loginRepository = loginRepository;
        _signInManager = signInManager;
        _jwtService = jwtService;
        _emailService = emailService;
    }
    public async Task<AuthResponse> Handle(AuthQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new AuthResponse { IsSuccessfully = false, Errors = new List<string> { "request null" } };
        
        if (string.IsNullOrEmpty(request.Email))
            return new AuthResponse { IsSuccessfully = false, Errors = new List<string> { "Email null" } };  
        
        if (string.IsNullOrEmpty(request.Password))
            return new AuthResponse { IsSuccessfully = false, Errors = new List<string> { "Password null" } };
        
        if (string.IsNullOrWhiteSpace(request.FirstName))
            return new AuthResponse { IsSuccessfully = false, Errors = new List<string> { "UserName null" } };
        
        var email = await _loginRepository.GetUserByEmail(request.Email, cancellationToken);

        if (email != null!) 
            return new AuthResponse { IsSuccessfully = false, Errors = new List<string> { "Такой пользователь уже зарегестрирован" } };
       

       

        UserInfo userInfo = new UserInfo
        {
            FullName = request.FirstName + " " + request.LastName,
            //MainImageId = 1,
        };
        

        User user = new User
        {
            FullName = request.FirstName + " " + request.LastName,
            UserName = request.FirstName + request.LastName  + DateTime.UtcNow.Ticks,
            PasswordHash = request.Password,
            Email = request.Email,
            UserInfo = userInfo
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return new AuthResponse
            {
                IsSuccessfully = false,
                Errors = result.Errors
                    .Select(x => x.Description)
                    .ToList()
            };
        }
        await _signInManager.SignInAsync(user, false);
        
        var token = _jwtService.GenerateToken(user);
        
        return new AuthResponse
        {
            IsSuccessfully = true, 
            Errors = null!, 
            Token = token
        };
    }
}