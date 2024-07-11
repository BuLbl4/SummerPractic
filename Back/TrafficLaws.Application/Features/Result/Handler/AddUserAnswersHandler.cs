using Domain.Entities;
using MediatR;
using TrafficLaws.Application.Features.Result.Query;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Result.Handler;

public class AddUserAnswersHandler : IRequestHandler<AddUserAnswersQuery, BaseResponse>
{
    private readonly IResultRepository _resultRepository;
    private readonly IUserRepository _userRepository;

    public AddUserAnswersHandler(IResultRepository resultRepository, IUserRepository userRepository)
    {
        _resultRepository = resultRepository;
        _userRepository = userRepository;
    }

    public async Task<BaseResponse> Handle(AddUserAnswersQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
            return new BaseResponse { IsSuccessfully = false };

        var user = await _userRepository.GetById(Guid.Parse(request.UserId), cancellationToken);
        
        var ans = new List<UserResultAnswers>();

        for (int i = 0; i < request.Score.Count; i++)
        {
            ans.Add(new UserResultAnswers
            {
                Id = Guid.NewGuid(),
                IsCorrect = request.Score[i].IsCorrect,
                QuestionId = Guid.Parse(request.Score[i].QuestionId),
                UserId = Guid.Parse(request.UserId)
            });
        }

        await _resultRepository.AddUserAnswers(ans, cancellationToken);

        await _resultRepository.AddResult(user.UserInfo.Id, Guid.Parse(request.TestId),
            request.CorrectAnswersCount, cancellationToken);

        return new BaseResponse
        {
            IsSuccessfully = true
        };
    }
}