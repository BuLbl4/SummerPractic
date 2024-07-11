using Domain.Entities;

namespace TrafficLaws.Application.Interfaces.Repository;

public interface IAnswerRepository
{
    Task Seed(CancellationToken cancellationToken);

    Task AddAnswers(List<string> answers, List<bool> isCorrect, Guid questionId, CancellationToken cancellationToken);

    Task<Answer> GetById(Guid answerId, CancellationToken cancellationToken);

    Task<List<Answer>> GetAnswersById(List<Guid> guids, CancellationToken cancellationToken);

    Task<List<Answer>> GetAllAnswerByQuestion(Guid questionId, CancellationToken cancellationToken);
}