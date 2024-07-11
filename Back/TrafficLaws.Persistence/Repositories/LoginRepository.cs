using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Persistence.Context;

namespace TrafficLaws.Persistence.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly EfContext _context;

    public LoginRepository(EfContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserInfo)
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}