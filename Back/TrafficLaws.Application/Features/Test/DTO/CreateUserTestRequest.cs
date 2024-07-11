namespace TrafficLaws.Application.Features.Test.DTO;

public class CreateUserTestRequest
{
    public CreateUserTestRequest()
    {
        
    }

    public CreateUserTestRequest(CreateUserTestRequest request)
    {
        Name = request.Name;
        Description = request.Description;
        UserId = request.UserId;
    }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string UserId { get; set; }
}