using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;
/// <summary>
/// Варианты ответов
/// </summary>
public class Answer : BaseEntity
{
    public string AnswerText { get; set; }
    
    public bool IsCorrect { get; set; }

    public Guid QuestionId { get; set; }
    
    [JsonIgnore]
    public Question Question { get; set; }
}