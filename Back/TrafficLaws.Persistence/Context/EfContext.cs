using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrafficLaws.Persistence.Configurations;
using TrafficLaws.Persistence.DbSeeder;

namespace TrafficLaws.Persistence.Context;

public class EfContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<UserInfo> UserInfos { get; set; }
    
    public DbSet<Test> Tests { get; set; }
    
    public DbSet<Question> Questions { get; set; }
    
    public DbSet<Answer> Answers { get; set; }
    
    public DbSet<UserResult> UserResults { get; set; }
    
    public DbSet<UserResultAnswers> UserResultAnswers { get; set; }
    public EfContext(DbContextOptions<EfContext> options) : base(options)
    {
    }

    public EfContext()
    {
        
    }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserInfoConfiguration());
        builder.ApplyConfiguration(new AnswerConfiguration());
        builder.ApplyConfiguration(new QuestionConfiguration());
        builder.ApplyConfiguration(new TestConfiguration());
        builder.ApplyConfiguration(new UserResultConfiguration());
        builder.ApplyConfiguration(new UserResultAnswerConfiguration());
        builder.Entity<Test>().HasData(Seeder.Tests());
        base.OnModelCreating(builder);
    }
}