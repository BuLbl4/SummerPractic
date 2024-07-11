using MediatR;
using TrafficLaws.Application.Features.Question.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Question.Queries;

public class CreateQuestionAndAnswerQuery : CreateQuestionAndAnswerRequest, IRequest<BaseResponse>
{
    public CreateQuestionAndAnswerQuery(CreateQuestionAndAnswerRequest request) : base(request)
    {
        
    }
}