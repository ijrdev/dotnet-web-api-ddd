using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain = Domains.Clients;

namespace Database.Mapping.Clients
{
    public class ClientsMapping : IEntityTypeConfiguration<Domain.Clients>
    {
        public void Configure(EntityTypeBuilder<Domain.Clients> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Document)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(c => c.Document).IsUnique();


            builder.Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Age).IsRequired();

            builder.Property(c => c.Person).IsRequired();
        }
    }
}
