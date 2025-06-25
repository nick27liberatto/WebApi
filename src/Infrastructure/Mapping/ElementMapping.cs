namespace Infrastructure.Mapping
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ElementMapping : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.ToTable("ELEMENTS");

            builder.HasKey(p => p.Id);
            builder.Property(_ => _.Name).IsRequired(true);
            builder.Property(_ => _.Password).IsRequired(true);
            builder.Property(_ => _.Text).IsRequired(false);
            builder.Property(_ => _.StaticStatus).IsRequired(false);
        }
    }
}
