namespace TrafficLaws.Application.Responses.Auth;

public class AuthResponse
{
    public bool IsSuccessfully { get; set; }
    
    public string Token { get; set; }
    
    public List<string> Errors { get; set; }
}