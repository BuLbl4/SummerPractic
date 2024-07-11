using System.Numerics;
using Domain.Entities;

namespace TrafficLaws.Application.Interfaces.Repository;

public interface IQuestionRepository
{
    Task<Question> CreateQuestion(string text, Guid testId,  bool onlyOneAnswer, CancellationToken cancellationToken);

    Task<List<Question>> GetQuestionByTestId(Guid id, CancellationToken cancellationToken);

    Task<Question> GetById(Guid id, CancellationToken cancellationToken);
}