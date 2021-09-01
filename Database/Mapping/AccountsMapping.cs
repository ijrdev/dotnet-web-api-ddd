using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Domain.Core.Entities;

namespace Infrastructure.Database.Core.Mapping
{
    public class AccountsMapping : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.HasIndex(a => a.AccountNumber).IsUnique();
            builder.Property(a => a.AccountNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Value).HasDefaultValue(0);

            //builder.Property(a => a.Client.Id).IsRequired();
        }
    }
}
