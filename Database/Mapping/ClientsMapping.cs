using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Data.Mapping
{
    public class ClientsMapping : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Document)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();
            //builder.HasIndex(c => c.Document).IsUnique();

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Password).IsRequired();

            builder.Property(c => c.Age).IsRequired();

            builder.Property(c => c.Person).IsRequired();
        }
    }
}
