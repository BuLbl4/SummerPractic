using MediatR;
using TrafficLaws.Application.Features.Result.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Result.Query;

public class CheckAnswerQuery : CheckAnswerRequest, IRequest<BaseResponse>
{
    public CheckAnswerQuery(CheckAnswerRequest request) : base(request)
    {
        
    }
}