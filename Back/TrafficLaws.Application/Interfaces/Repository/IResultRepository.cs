using Domain.Entities;

namespace TrafficLaws.Application.Interfaces.Repository;

public interface IResultRepository
{
    Task AddResult(Guid userId, Guid testId, int score, CancellationToken cancellationToken);

    Task AddUserAnswers(List<UserResultAnswers> answersList, CancellationToken cancellationToken);

    Task<List<UserResult>> GetUserRessult(Guid userId, CancellationToken cancellationToken);
}