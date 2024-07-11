using MediatR;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Auth.Queries;

public class ForgotPasswordQuery : ForgotPasswordRequest, IRequest<BaseResponse>
{
    public ForgotPasswordQuery(ForgotPasswordRequest request) : base(request)
    {
        
    }
}