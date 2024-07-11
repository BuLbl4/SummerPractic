using Domain.Entities;

namespace TrafficLaws.Application.Interfaces.Repository;

public interface ILoginRepository
{
    public Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);

}