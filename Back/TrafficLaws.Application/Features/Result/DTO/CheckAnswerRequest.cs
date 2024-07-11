namespace TrafficLaws.Application.Features.Result.DTO;

public class CheckAnswerRequest
{
    public CheckAnswerRequest()
    {
        
    }

    public CheckAnswerRequest(CheckAnswerRequest request)
    {
        QuestionId = request.QuestionId;
        UserId = request.UserId;
        AnswerId = request.AnswerId;
    }
    
    public string QuestionId { get; set; }
    
    public string UserId { get; set; }
    
    public string AnswerId { get; set; }
}