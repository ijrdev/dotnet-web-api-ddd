using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Database.Mapping
{
    public class AccountsMapping : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.AccountNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();
            //builder.HasIndex(a => a.AccountNumber).IsUnique();

            builder.Property(a => a.Balance).HasDefaultValue(0);
        }
    }
}
