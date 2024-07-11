using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Persistence.Context;

namespace TrafficLaws.Persistence.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly EfContext _context;
    public AnswerRepository(EfContext efContext)
    {
        _context = efContext;
    }
    public async Task Seed(CancellationToken cancellationToken)
    {
        var answer1 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("afdd6ad6-8248-4c5d-80e0-6de5ea6fab19"),
            AnswerText = "30 км/ч",
            IsCorrect = true
        };

        var answer2 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("afdd6ad6-8248-4c5d-80e0-6de5ea6fab19"),
            AnswerText = "50 км/ч",
            IsCorrect = false
        };

        var answer3 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("afdd6ad6-8248-4c5d-80e0-6de5ea6fab19"),
            AnswerText = "60 км/ч",
            IsCorrect = false
        };

        var answer4 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("afdd6ad6-8248-4c5d-80e0-6de5ea6fab19"),
            AnswerText = "70 км/ч",
            IsCorrect = false
        };

        var answer5 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("7c1f8fc5-af8f-4580-838d-2ec34065a1a2"),
            AnswerText = "Остановиться и ждать зеленого сигнала",
            IsCorrect = true
        };

        var answer6 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("7c1f8fc5-af8f-4580-838d-2ec34065a1a2"),
            AnswerText = "Проехать с осторожностью",
            IsCorrect = false
        };

        var answer7 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("7c1f8fc5-af8f-4580-838d-2ec34065a1a2"),
            AnswerText = "Повернуть налево, если нет машин",
            IsCorrect = false
        };

        var answer8 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("7c1f8fc5-af8f-4580-838d-2ec34065a1a2"),
            AnswerText = "Ускориться",
            IsCorrect = false
        };

        var answer9 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("1507e32f-a9bb-4c64-91b7-91bd3173bd25"),
            AnswerText = "Штраф и баллы на лицензию",
            IsCorrect = true
        };

        var answer10 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("1507e32f-a9bb-4c64-91b7-91bd3173bd25"),
            AnswerText = "Только штраф",
            IsCorrect = false
        };

        var answer11 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("1507e32f-a9bb-4c64-91b7-91bd3173bd25"),
            AnswerText = "Предупреждение",
            IsCorrect = false
        };

        var answer12 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("1507e32f-a9bb-4c64-91b7-91bd3173bd25"),
            AnswerText = "Без наказания",
            IsCorrect = false
        };

        var answer13 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("3083f8b7-ee0c-4fae-8770-9e2faaa8680e"),
            AnswerText = "Остановиться и пропустить пешехода",
            IsCorrect = true
        };

        var answer14 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("3083f8b7-ee0c-4fae-8770-9e2faaa8680e"),
            AnswerText = "Посигналить пешеходу",
            IsCorrect = false
        };

        var answer15 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("3083f8b7-ee0c-4fae-8770-9e2faaa8680e"),
            AnswerText = "Ускориться, чтобы пройти перед пешеходом",
            IsCorrect = false
        };

        var answer16 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = Guid.Parse("3083f8b7-ee0c-4fae-8770-9e2faaa8680e"),
            AnswerText = "Игнорировать пешехода",
            IsCorrect = false
        };

        var ans =  new List<Answer>
        {
            answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10, answer11,
            answer12, answer13, answer14, answer15, answer16
        };
        await _context.Answers.AddRangeAsync(ans, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAnswers(List<string> answers, List<bool> isCorrect, Guid questionId, CancellationToken cancellationToken)
    {
        var ans = new List<Answer>();
        
        for (int i = 0; i < answers.Count; i++)
        {
            ans.Add(new Answer
            {
                Id = Guid.NewGuid(),
                AnswerText = answers[i],
                IsCorrect = isCorrect[i],
                QuestionId = questionId
            });
        }

        await _context.Answers.AddRangeAsync(ans, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Answer> GetById(Guid answerId, CancellationToken cancellationToken)
    {
        return await _context.Answers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == answerId, cancellationToken) ?? null; 
    }

    public async Task<List<Answer>> GetAnswersById(List<Guid> guids, CancellationToken cancellationToken)
    {
        return await _context.Answers.AsNoTracking()
            .Where(x => guids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Answer>> GetAllAnswerByQuestion(Guid questionId, CancellationToken cancellationToken)
    {
        return await _context.Answers.AsNoTracking().Where(x => x.QuestionId == questionId).ToListAsync(cancellationToken);
    }
}