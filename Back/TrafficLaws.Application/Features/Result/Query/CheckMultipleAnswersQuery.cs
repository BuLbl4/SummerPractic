using MediatR;
using TrafficLaws.Application.Features.Result.DTO;
using TrafficLaws.Application.Responses.Result;

namespace TrafficLaws.Application.Features.Result.Query;

public class CheckMultipleAnswersQuery : CheckMultipleAnswersRequest, IRequest<MultipleAnswerResponse>
{
    public CheckMultipleAnswersQuery(CheckMultipleAnswersRequest request) : base(request)
    {
        
    }
}