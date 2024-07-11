using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrafficLaws.Persistence.Configurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Birthday)
            .HasColumnType("date");
        
        builder.HasOne(x => x.User)
            .WithOne(x => x.UserInfo)
            .HasForeignKey<UserInfo>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id);
    }
}