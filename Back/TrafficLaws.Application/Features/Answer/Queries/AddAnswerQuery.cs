using MediatR;
using TrafficLaws.Application.Features.Answer.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Answer.Queries;

public class AddAnswerQuery : AddAnswerRequest, IRequest<BaseResponse>
{
    public AddAnswerQuery(AddAnswerRequest request) : base(request)
    {
        
    }
}