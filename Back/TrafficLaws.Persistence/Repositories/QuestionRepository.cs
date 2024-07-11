using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Persistence.Context;

namespace TrafficLaws.Persistence.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly EfContext _context;

    public QuestionRepository(EfContext context)
    {
        _context = context;
    }
    public async Task<Question> CreateQuestion(string text, Guid testId, bool onlyOneAnswer, CancellationToken cancellationToken)
    {
        var question = new Question
        {
            Id = Guid.NewGuid(),
            QuestionText = text,
            TestId = testId,
            OnlyOneAnswer = onlyOneAnswer
        };

        await _context.Questions.AddAsync(question, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return question;
    }

    public async Task<List<Question>> GetQuestionByTestId(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Questions
            .AsNoTracking()
            .Include(x => x.Answers)
            .Where(x => x.TestId == id)
            .ToListAsync(cancellationToken);
    }

    public async Task<Question> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Questions
            .AsNoTracking().
            FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}