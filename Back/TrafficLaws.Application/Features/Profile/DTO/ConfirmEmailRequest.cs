namespace TrafficLaws.Application.Features.Profile.DTO;

public class ConfirmEmailRequest
{
    public ConfirmEmailRequest()
    {
        
    }

    public ConfirmEmailRequest(ConfirmEmailRequest request)
    {
        Email = request.Email;
    }
    
    public string Email { get; set; }
}