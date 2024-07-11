using Domain.Entities;

namespace TrafficLaws.Application.Interfaces.Repository;

public interface ITestRepository
{
    Task<List<Test>> GetTests(CancellationToken cancellationToken);

    Task<Test> GetRandomTest(CancellationToken cancellationToken);

    Task<Test?> GetTestById(Guid id, CancellationToken cancellationToken);

    Task<Test> CreateTest(string title, string description, CancellationToken cancellationToken);
}