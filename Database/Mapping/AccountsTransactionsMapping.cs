using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class AccountsTransactionsMapping : IEntityTypeConfiguration<AccountsTransactions>
    {
        public void Configure(EntityTypeBuilder<AccountsTransactions> builder)
        {
            builder.ToTable("AccountsTransactions");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.TransactionType).IsRequired();

            builder.Property(a => a.Operation).IsRequired();

            builder.Property(a => a.Value).HasDefaultValue(0);

            builder.Property(c => c.Account.Id).IsRequired();
        }
    }
}
