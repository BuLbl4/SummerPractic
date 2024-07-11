using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Persistence.Context;

namespace TrafficLaws.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EfContext _context;

    public UserRepository(EfContext context)
    {
        _context = context;
    }
    public async Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserInfo)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }


    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserInfo)
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}