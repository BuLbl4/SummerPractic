using MediatR;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Auth.Queries;

public class ResetPasswordQuery : ResetPasswordRequest, IRequest<BaseResponse>
{
    public ResetPasswordQuery(ResetPasswordRequest request) : base(request)
    { }
}