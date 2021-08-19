using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain = Domains.Accounts;

namespace Database.Mapping.Clients
{
    public class AccountsMapping : IEntityTypeConfiguration<Domain.Accounts>
    {
        public void Configure(EntityTypeBuilder<Domain.Accounts> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.AccountType).IsRequired();
            builder.HasIndex(a => a.AccountType)
                .IsUnique();

            builder.Property(a => a.AccountNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Balance)
                .HasDefaultValue(0);
        }
    }
}
