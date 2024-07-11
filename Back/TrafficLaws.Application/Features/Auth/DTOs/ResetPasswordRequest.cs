namespace TrafficLaws.Application.Features.Auth.DTOs;

public class ResetPasswordRequest
{
    public ResetPasswordRequest()
    { }

    public ResetPasswordRequest(ResetPasswordRequest request)
    {
        Password = request.Password;
        Email = request.Email;
    }
    public string Password { get; set; }
    
    public string Email { get; set; }
}