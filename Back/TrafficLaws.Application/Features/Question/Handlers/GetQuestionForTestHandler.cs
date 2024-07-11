using MediatR;
using TrafficLaws.Application.Features.Question.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Question;

namespace TrafficLaws.Application.Features.Question.Handlers;

public class GetQuestionForTestHandler : IRequestHandler<GetQuestionsForTestQuery, QuestionResponse>
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionForTestHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task<QuestionResponse> Handle(GetQuestionsForTestQuery request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetQuestionByTestId(Guid.Parse(request.TestId), cancellationToken);

        if (question == null!)
            return new QuestionResponse { IsSuccessfully = false };

        return new QuestionResponse
        {
            IsSuccessfully = true,
        };
    }
}