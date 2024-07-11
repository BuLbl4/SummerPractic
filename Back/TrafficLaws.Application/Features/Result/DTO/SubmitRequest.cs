namespace TrafficLaws.Application.Features.Result.DTO;

public class SubmitRequest
{
    public SubmitRequest()
    { }

    public SubmitRequest(SubmitRequest request)
    {
        UserId = request.UserId;
        Score = request.Score;
        TestId = request.TestId;
    }
    
    public string UserId { get; set; }
    public int Score { get; set; }
    public string TestId { get; set; }
    
}