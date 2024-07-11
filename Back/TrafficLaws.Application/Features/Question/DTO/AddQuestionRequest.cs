namespace TrafficLaws.Application.Features.Question.DTO;

public class AddQuestionRequest
{

    public AddQuestionRequest()
    { }

    public AddQuestionRequest(AddQuestionRequest request)
    {
        QuestionText = request.QuestionText;
        TestId = request.TestId;
    }
    public string QuestionText { get; set; }
    
    public string TestId { get; set; }
}