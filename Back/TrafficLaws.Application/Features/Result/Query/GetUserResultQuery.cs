using MediatR;
using TrafficLaws.Application.Features.Result.DTO;
using TrafficLaws.Application.Responses.Result;

namespace TrafficLaws.Application.Features.Result.Query;

public class GetUserResultQuery : GetUserResultRequest, IRequest<UserResultResponse>
{
    public GetUserResultQuery(GetUserResultRequest request) : base(request)
    {
        
    }
}