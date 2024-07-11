namespace TrafficLaws.Application.Features.Profile.DTO;

public class  GetUserByIdRequest
{
    public GetUserByIdRequest()
    { }

    public GetUserByIdRequest(GetUserByIdRequest request)
    {
        Id = request.Id;
    }
    
    public string Id { get; set; }
}