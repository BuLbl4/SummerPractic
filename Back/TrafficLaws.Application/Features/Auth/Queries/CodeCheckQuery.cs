using MediatR;
using TrafficLaws.Application.Features.Auth.DTOs;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Auth.Queries;

public class CodeCheckQuery : CodeCheckRequest, IRequest<BaseResponse>
{
    public CodeCheckQuery(CodeCheckRequest request) : base(request)
    { }
}