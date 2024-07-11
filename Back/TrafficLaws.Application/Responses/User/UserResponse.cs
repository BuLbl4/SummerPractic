using Domain.Entities;

namespace TrafficLaws.Application.Responses.User;

public class UserResponse : BaseResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public UserInfo UserInfo { get; set; }
    
    public bool EmailConfirm { get; set; }
         
}