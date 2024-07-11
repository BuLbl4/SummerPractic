namespace TrafficLaws.Application.Features.Test.DTO;

public class GetTestByIdRequest
{
    public GetTestByIdRequest()
    { }

    public GetTestByIdRequest(GetTestByIdRequest request)
    {
        Id = request.Id;
    }
    
    public string Id { get; set; }
}