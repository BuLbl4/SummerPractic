using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Auth.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;


namespace TrafficLaws.Application.Features.Auth.Handlers;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordQuery, BaseResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;

    public ResetPasswordHandler(UserManager<User> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }
    public async Task<BaseResponse> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email, cancellationToken);

        if (user == null)
            return new BaseResponse { Errors = new List<string> { "User not found" } };

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        
        var result = await _userManager.ResetPasswordAsync(user, token, request.Password);

        if (result.Succeeded)
            return new BaseResponse { IsSuccessfully = true, Message = "Password changed successfully " };
        

        return new BaseResponse
        {
            Errors = result.Errors
                .Select(x => x.Description)
                .ToList()
        };
    }
}