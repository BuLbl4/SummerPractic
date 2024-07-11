using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;

public class UserInfo : BaseEntity
{
    
    public string FullName { get; set; }
    
    /// <summary>
    /// День рождения
    /// </summary>
    public DateTime? Birthday { get; set; }
    /// <summary>
    /// Nav-prop
    /// </summary>
    [JsonIgnore]
    public User? User { get; set; }

    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    public IList<UserResult> Results { get; set; }
    
    
}