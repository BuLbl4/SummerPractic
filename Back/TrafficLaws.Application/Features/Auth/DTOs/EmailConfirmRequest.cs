namespace TrafficLaws.Application.Features.Auth.DTOs;

public class EmailConfirmRequest
{
    public EmailConfirmRequest()
    { }

    public EmailConfirmRequest(EmailConfirmRequest request)
    {
        UserId = request.UserId;
    }
    
    public string UserId { get; set; }
}