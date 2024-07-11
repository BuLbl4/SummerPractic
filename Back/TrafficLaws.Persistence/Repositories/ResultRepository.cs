using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Persistence.Context;

namespace TrafficLaws.Persistence.Repositories;

public class ResultRepository : IResultRepository
{
    private readonly EfContext _efContext;

    public ResultRepository(EfContext efContext)
    {
        _efContext = efContext;
    }
    public async Task AddResult(Guid userId, Guid testId, int score, CancellationToken cancellationToken)
    {
        await _efContext.UserResults.AddAsync(new UserResult
        {
            Id = Guid.NewGuid(),
            Score = score,
            TestId = testId,
            UserId = userId,
            CompletedAt = DateTime.UtcNow
        }, cancellationToken);

        await _efContext.SaveChangesAsync(cancellationToken);

    }

    public async Task AddUserAnswers(List<UserResultAnswers> answersList, CancellationToken cancellationToken)
    {
        await _efContext.UserResultAnswers.AddRangeAsync(answersList, cancellationToken);
        await _efContext.SaveChangesAsync(cancellationToken);

    }

    public async Task<List<UserResult>> GetUserRessult(Guid userId, CancellationToken cancellationToken)
    {
        return await _efContext.UserResults
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Include(x => x.Test)
            .ToListAsync(cancellationToken);
    }
}