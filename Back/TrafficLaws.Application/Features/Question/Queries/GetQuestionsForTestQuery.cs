using MediatR;
using TrafficLaws.Application.Features.Question.DTO;
using TrafficLaws.Application.Responses.Question;

namespace TrafficLaws.Application.Features.Question.Queries;

public class GetQuestionsForTestQuery : GetQuestionsForTestRequest, IRequest<QuestionResponse>
{
    public GetQuestionsForTestQuery(GetQuestionsForTestRequest request) : base(request)
    {
        
    }
}