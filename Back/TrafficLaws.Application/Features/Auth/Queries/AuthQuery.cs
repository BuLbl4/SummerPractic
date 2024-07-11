using MediatR;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Responses.Auth;

namespace TrafficLaws.Application.Features.Auth.Queries;

public class AuthQuery : AuthRequest, IRequest<AuthResponse>
{
    public AuthQuery(AuthRequest authRequest) : base(authRequest)
    {
        
    }
}