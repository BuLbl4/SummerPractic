namespace TrafficLaws.Application.Features.Answer.DTO;

public class AddAnswerRequest
{
    public AddAnswerRequest()
    { }

    public AddAnswerRequest(AddAnswerRequest request)
    {
        Answers = request.Answers;
        IsCorrect = request.IsCorrect;
        QuestionId = request.QuestionId;
    }
    
    public List<string> Answers { get; set; }
    
    public List<bool> IsCorrect { get; set; }
    
    public string QuestionId { get; set; }
}