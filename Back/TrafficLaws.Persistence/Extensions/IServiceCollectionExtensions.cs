using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Persistence.Context;
using TrafficLaws.Persistence.Repositories;

namespace TrafficLaws.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EfContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = true;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<EfContext>()
                .AddDefaultTokenProviders();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<ITestRepository, TestRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ILoginRepository, LoginRepository>()
                .AddScoped<IQuestionRepository, QuestionRepository>()
                .AddScoped<IResultRepository, ResultRepository>()
                .AddScoped<IAnswerRepository, AnswerRepository>();
        }
    }
}