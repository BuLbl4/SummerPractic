using MediatR;
using TrafficLaws.Application.Features.Result.DTO;
using TrafficLaws.Application.Responses.Result;

namespace TrafficLaws.Application.Features.Result.Query;

public class SubmitResultQuery : SubmitRequest, IRequest<ResultResponse>
{
    public SubmitResultQuery(SubmitRequest request) : base(request)
    {
        
    }
}