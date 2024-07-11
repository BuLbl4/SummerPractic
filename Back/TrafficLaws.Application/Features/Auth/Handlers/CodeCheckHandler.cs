using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TrafficLaws.Application.Features.Auth.Queries;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Auth.Handlers;

public class CodeCheckHandler : IRequestHandler<CodeCheckQuery, BaseResponse>
{
    private readonly UserManager<User> _userManager;

    public CodeCheckHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<BaseResponse> Handle(CodeCheckQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return new BaseResponse
            {
                Errors = new List<string> { "User not found" }
            };
        }

        var claims = await _userManager.GetClaimsAsync(user);

        if (claims == null)
            return new BaseResponse { Errors = new List<string> { "Claims is empty" } };

        var claim = claims.FirstOrDefault(c => c.Type == request.CodeType && c.Value == request.Code);
        
        
        if (claim == null)
            return new BaseResponse { Errors = new List<string> {"Invalid confirmation code"}};

        if (request.CodeType == "ConfirmEmailCode")
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await _userManager.ConfirmEmailAsync(user, code);
        }
        
        await _userManager.RemoveClaimAsync(user, claim);
        
        return new BaseResponse
        {
            IsSuccessfully = true,
            Message = "Code successfully verified"
        };
    }
}