namespace TrafficLaws.Application.Features.Profile.DTO;

public class EditPasswordRequest
{
    public EditPasswordRequest() { }

    public EditPasswordRequest(EditPasswordRequest request)
    {
        CurrentPassword = request.CurrentPassword;
        NewPassword = request.NewPassword;
        ConfirmPassword = request.ConfirmPassword;
        UserId = request.UserId;
    }
    public string CurrentPassword { get; set; }
    
    public string NewPassword { get; set; }
    
    public string ConfirmPassword { get; set; }
    
    public string UserId { get; set; }
}