using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;
/// <summary>
/// Билет
/// </summary>
public class Test : BaseEntity
{
    public string Title { get; set; }

    public string? Description { get; set; }
    
    public int SerialNumber { get; set; }
    
    public List<Question> Questions { get; set; }
}