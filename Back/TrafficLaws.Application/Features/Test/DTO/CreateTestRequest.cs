namespace TrafficLaws.Application.Features.Test.DTO;

public class CreateTestRequest
{

    public CreateTestRequest()
    { }

    public CreateTestRequest(CreateTestRequest request)
    {
        Title = request.Title;
        Description = request.Description;
    }
    public string Title { get; set; }
    
    public string Description { get; set; }
}