namespace TrafficLaws.Application.Features.Question.DTO;

public class GetQuestionsForTestRequest
{
    public GetQuestionsForTestRequest()
    { }

    public GetQuestionsForTestRequest(GetQuestionsForTestRequest request)
    {
        TestId = request.TestId;
    }
    
    public string TestId { get; set; }
}