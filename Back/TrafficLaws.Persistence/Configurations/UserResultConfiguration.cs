using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrafficLaws.Persistence.Configurations;

public class UserResultConfiguration : IEntityTypeConfiguration<UserResult>
{
    public void Configure(EntityTypeBuilder<UserResult> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Score)
            .IsRequired();

        builder.Property(x => x.CompletedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.UserId);

    }
}