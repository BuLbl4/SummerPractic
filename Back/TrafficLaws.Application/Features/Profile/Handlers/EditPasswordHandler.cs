using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Profile.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Profile.Handlers;

public class EditPasswordHandler : IRequestHandler<EditPasswordQuery, BaseResponse>
{
    private readonly UserManager<User> _userManager;

    private readonly IUserRepository _userRepository;
    public EditPasswordHandler(UserManager<User> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }
    public async Task<BaseResponse> Handle(EditPasswordQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return new BaseResponse { Errors = new List<string> {"Пользователь не найден"} };
        }
        
        var passwordValid = await _userManager.CheckPasswordAsync(user, request.CurrentPassword);
        
        if (!passwordValid)
        {
            return new BaseResponse { Errors = new List<string> {"Пароль не правильный"} };
        }

        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (result.Succeeded)
        {
            return new BaseResponse { IsSuccessfully = true, Errors = null! };
        }

        return new BaseResponse { Message = "Что то пошло не так" };
    }
}