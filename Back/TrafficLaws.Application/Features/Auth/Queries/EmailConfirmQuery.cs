using MediatR;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Responses.Auth;

namespace TrafficLaws.Application.Features.Auth.Queries;

public class EmailConfirmQuery : EmailConfirmRequest , IRequest<EmailConfirmResponse>
{
    public EmailConfirmQuery(EmailConfirmRequest request) : base(request)
    {
        
    }
}