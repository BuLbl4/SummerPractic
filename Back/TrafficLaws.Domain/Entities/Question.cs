using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;
/// <summary>
/// Вопросы
/// </summary>
public class Question : BaseEntity
{
    public string QuestionText { get; set; }

    public Guid TestId { get; set; }
    
    public bool OnlyOneAnswer { get; set; }
    
    [JsonIgnore]
    public Test Test { get; set; }
    
    public List<Answer> Answers { get; set; }
}