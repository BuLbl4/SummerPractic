using MediatR;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Responses.Auth;

namespace TrafficLaws.Application.Features.Auth.Queries;

public class LoginQuery : LoginRequest, IRequest<AuthResponse>
{
    public LoginQuery(LoginRequest loginRequest) : base(loginRequest)
    {
        
    }
}