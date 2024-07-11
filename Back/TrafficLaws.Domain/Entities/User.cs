using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; }
    [JsonIgnore]
    public UserInfo UserInfo { get; set; }
}