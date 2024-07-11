namespace TrafficLaws.Application.Responses.Result;

public class MultipleAnswerResponse : BaseResponse
{
    public List<Guid> IncorrectAnswerIds { get; set; }
}