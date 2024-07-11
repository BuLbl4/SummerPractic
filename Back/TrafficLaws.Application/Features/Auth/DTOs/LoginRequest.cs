namespace TrafficLaws.Application.Features.Auth.DTOs;

public class LoginRequest
{
    public LoginRequest()
    {
    }
    public LoginRequest(LoginRequest request)
    {
        Password = request.Password;
        Email = request.Email;
    }
    public string Password { get; set; }
    
    public string Email { get; set; }
}