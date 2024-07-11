namespace TrafficLaws.Application.Features.Auth.DTOs;

public class AuthRequest
{
    public AuthRequest()
    {
    }
    public AuthRequest(AuthRequest request)
    {
        Password = request.Password;
        Email = request.Email;
        FirstName = request.FirstName;
        LastName = request.LastName;
    }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}