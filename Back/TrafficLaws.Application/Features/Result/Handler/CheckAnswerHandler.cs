using MediatR;
using TrafficLaws.Application.Features.Result.Query;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Result.Handler;

public class CheckAnswerHandler : IRequestHandler<CheckAnswerQuery, BaseResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IAnswerRepository _answerRepository;

    public CheckAnswerHandler(IUserRepository userRepository, IAnswerRepository answerRepository)
    {
        _userRepository = userRepository;
        _answerRepository = answerRepository;
    }
    public async Task<BaseResponse> Handle(CheckAnswerQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(Guid.Parse(request.UserId), cancellationToken);

        if (user == null!)
            return new BaseResponse { IsSuccessfully = false, Message = "User not found" };

        var answer = await _answerRepository.GetById(Guid.Parse(request.AnswerId), cancellationToken);

        if (answer == null)
        {
            return new BaseResponse { IsSuccessfully = false, Message = "answer not found" };
        }

        if (Guid.Parse(request.QuestionId) == answer.QuestionId && answer.IsCorrect)
        {
            return new BaseResponse
            {
                IsSuccessfully = true,
                Message = "Correct"
            };
        }

        else if(!answer.IsCorrect && Guid.Parse(request.QuestionId) == answer.QuestionId)
        {
            return new BaseResponse
            {
                IsSuccessfully = true,
                Message = "Not Correct"
            };
        }

        return new BaseResponse
        {
            IsSuccessfully = false
        };
    }
}