using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TrafficLaws.Persistence.Context;

public class EfContextFactory : IDesignTimeDbContextFactory<EfContext>
{
    /// <inheritdoc />
    public EfContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder().Build();
        
        var optionBuilder = new DbContextOptionsBuilder<EfContext>();
        optionBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=Bulat2004;Database=ForPractic");

        return new EfContext(optionBuilder.Options);
    }
}