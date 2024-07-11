
namespace TrafficLaws.Application.Features.Result.DTO;

public class UserAnswerRequest
{
    public UserAnswerRequest()
    {
    }

    public UserAnswerRequest(UserAnswerRequest request)
    {
        UserId = request.UserId;
        Score = request.Score;
        TestId = request.TestId;
        CorrectAnswersCount = request.CorrectAnswersCount;
    }

    public string UserId { get; set; }

    public List<QuestionDictionary> Score { get; set; }

    public string TestId { get; set; }
    
    public int CorrectAnswersCount { get; set; }
}