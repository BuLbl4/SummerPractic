using Domain.Common;

namespace Domain.Entities;
/// <summary>
/// Информация об ответах пользователей
/// </summary>
public class UserResultAnswers : BaseEntity
{
    public Guid UserId { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public bool IsCorrect { get; set; }
}