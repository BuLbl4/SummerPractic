
namespace TrafficLaws.Application.Features.Result.DTO;

public class GetUserResultRequest
{
    public GetUserResultRequest()
    { }

    public GetUserResultRequest(GetUserResultRequest request)
    {
        UserId = request.UserId;
    }
    
    public string UserId { get; set; }
}