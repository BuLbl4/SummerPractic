namespace TrafficLaws.Application.Features.Result.DTO;

public class CheckMultipleAnswersRequest
{
    public CheckMultipleAnswersRequest()
    { }

    public CheckMultipleAnswersRequest(CheckMultipleAnswersRequest request)
    {
        UserId = request.UserId;
        QuestionId = request.QuestionId;
        AnswerId = request.AnswerId;
    }
    
    public string UserId { get; set; }
    public string QuestionId { get; set; }
    public List<Guid> AnswerId { get; set; }
}