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
            builder.HasKey(p => p.Id).HasName("ID_ELEMENT");

            builder.Property(e => e.Id).HasColumnName("ID_ELEMENT");
            builder.Property(e => e.Name).HasColumnName("NAME").HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Password).HasColumnName("PASSWORD").HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Text).HasColumnName("TEXT").HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.Status).HasColumnName("STATUS").IsRequired(false);
        }
    }
}
