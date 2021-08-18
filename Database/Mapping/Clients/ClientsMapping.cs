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

            builder.Property(c => c.Cpf)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Person).IsRequired();
        }
    }
}
