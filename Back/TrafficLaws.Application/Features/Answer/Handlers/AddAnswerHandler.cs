using MediatR;
using TrafficLaws.Application.Features.Answer.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Answer.Handlers;

public class AddAnswerHandler : IRequestHandler<AddAnswerQuery, BaseResponse>
{
    private readonly IAnswerRepository _answerRepository;

    public AddAnswerHandler(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }
    public async Task<BaseResponse> Handle(AddAnswerQuery request, CancellationToken cancellationToken)
    {
        if (request.Answers == null! || request.IsCorrect == null!)
        {
            return new BaseResponse
            {
                IsSuccessfully = false
            };
        }
        if (request.Answers.Count == request.IsCorrect.Count)
        {
            await _answerRepository.AddAnswers(request.Answers, request.IsCorrect, Guid.Parse(request.QuestionId),
                cancellationToken);
            
            return new BaseResponse
            {
                IsSuccessfully = true,
                Message = "Add answers"
            };
        }

        return new BaseResponse
        {
            IsSuccessfully = false,
            Message = "Кол-во данных не валидно"
        };
    }
}