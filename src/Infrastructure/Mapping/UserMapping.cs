using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");

            builder.HasKey(p => p.Id);
            builder.Property(_ => _.Username).IsRequired();
            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.Password).IsRequired();
            builder.Property(_ => _.Status).IsRequired();
        }
    }
}
