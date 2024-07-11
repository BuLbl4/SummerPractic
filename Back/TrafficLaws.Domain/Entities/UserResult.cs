using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;

/// <summary>
/// Результаты пользователей
/// </summary>
public class UserResult : BaseEntity
{
    public Guid UserId { get; set; }
    [JsonIgnore]
    public UserInfo User { get; set; }
    
    public Guid TestId { get; set; }
    [JsonIgnore]
    public Test Test { get; set; }
    
    public int Score { get; set; }
    
    public DateTime CompletedAt { get; set; }

}