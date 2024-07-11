using MediatR;
using TrafficLaws.Application.Features.Question.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Question.Queries;

public class AddQuestionsQuery : AddQuestionRequest, IRequest<BaseResponse>
{
    public AddQuestionsQuery(AddQuestionRequest request) : base(request)
    { }   
}