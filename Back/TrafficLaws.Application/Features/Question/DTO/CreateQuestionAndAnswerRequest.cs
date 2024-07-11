namespace TrafficLaws.Application.Features.Question.DTO;

public class CreateQuestionAndAnswerRequest
{
    public CreateQuestionAndAnswerRequest()
    {
        
    }

    public CreateQuestionAndAnswerRequest(CreateQuestionAndAnswerRequest request)
    {
        TestId = request.TestId;
        QuestionType = request.QuestionType;
        Question = request.Question;
        Options = request.Options;
        CorrectAnswers = request.CorrectAnswers;
    }
    
    public string TestId { get; set; }
    
    public string Question { get; set; }
    
    public List<string> Options { get; set; }
    
    public List<string> CorrectAnswers { get; set; }
    
    public string QuestionType { get; set; }
}