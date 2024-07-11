using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrafficLaws.Persistence.Configurations;

public class UserResultAnswerConfiguration : IEntityTypeConfiguration<UserResultAnswers>
{
    public void Configure(EntityTypeBuilder<UserResultAnswers> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.QuestionId)
            .IsRequired();
        
    }
}