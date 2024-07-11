namespace TrafficLaws.Application.Features.Auth.DTOs;

public class ForgotPasswordRequest
{
    public ForgotPasswordRequest()
    { }

    public ForgotPasswordRequest(ForgotPasswordRequest request)
    {
        Email = request.Email;
    }

    public string Email { get; set; }
}