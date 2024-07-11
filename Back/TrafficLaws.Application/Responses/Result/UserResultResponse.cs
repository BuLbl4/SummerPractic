using Domain.Entities;

namespace TrafficLaws.Application.Responses.Result;

public class UserResultResponse : BaseResponse
{
    public List<UserResult> Results { get; set; }
    
    public List<Domain.Entities.Test> Tests { get; set; }
    
}