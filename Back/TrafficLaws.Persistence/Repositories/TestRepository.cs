using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Persistence.Context;

namespace TrafficLaws.Persistence.Repositories;

public class TestRepository : ITestRepository
{
    private readonly EfContext _context;

    public TestRepository(EfContext context)
    {
        _context = context;
    }
    public Task<List<Test>> GetTests(CancellationToken cancellationToken)
    {
        return _context.Tests
            .AsNoTracking()
            .Include(x => x.Questions)
            .ThenInclude(x => x.Answers)
            .ToListAsync(cancellationToken);
    }

    public async Task<Test> GetRandomTest(CancellationToken cancellationToken)
    {
        return await _context.Tests
            .AsNoTracking()
            .Include(x => x.Questions)
            .ThenInclude(x => x.Answers)
            .OrderBy(t => Guid.NewGuid())
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Test?> GetTestById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Tests
            .AsNoTracking()
            .Include(x => x.Questions)
            .ThenInclude(x => x.Answers)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Test> CreateTest(string title, string description, CancellationToken cancellationToken)
    {
        var test = new Test
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description
        };
        await _context.Tests.AddAsync(test, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return test;
    }
}