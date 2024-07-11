
using Domain.Entities;

namespace TrafficLaws.Application.Responses.Test;

public class TestResponse : BaseResponse
{
    public string TestName { get; set; }
    
    public string Description { get; set; }
    
    public string Id { get; set; }
    
    public List<Domain.Entities.Question> Questions { get; set; }
    
    public List<List<string>> Answers { get; set; }
}