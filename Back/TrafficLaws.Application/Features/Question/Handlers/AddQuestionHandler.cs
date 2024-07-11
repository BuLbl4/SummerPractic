using MediatR;
using TrafficLaws.Application.Features.Question.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Question.Handlers;

public class AddQuestionHandler :  IRequestHandler<AddQuestionsQuery,BaseResponse>
{
    private readonly IQuestionRepository _questionRepository;

    public AddQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task<BaseResponse> Handle(AddQuestionsQuery request, CancellationToken cancellationToken)
    {
        var res = await _questionRepository.CreateQuestion(request.QuestionText, Guid.Parse(request.TestId), true, cancellationToken);

        return new BaseResponse
        {
            IsSuccessfully = true,
            Message = $"Create question id :{res.Id}"
        };
    }
}