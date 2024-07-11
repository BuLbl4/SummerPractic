using Domain.Entities;

namespace TrafficLaws.Application.Interfaces.Repository;

public interface IUserRepository
{
    public Task<User?> GetById(Guid id, CancellationToken cancellationToken);
    
    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken);


}