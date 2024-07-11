using Domain.Entities;

namespace TrafficLaws.Application.Responses.Question;

public class QuestionResponse : BaseResponse
{
    public Domain.Entities.Question Question { get; set; }
    
    public List<Answer> Answers { get; set; }
}