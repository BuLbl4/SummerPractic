using Domain.Entities;

public interface IJwtService
{
    public string GenerateToken(User user);
}