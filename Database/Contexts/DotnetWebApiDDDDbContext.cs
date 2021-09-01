using Infrastructure.Database.Core.Mapping;
using Domain.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Database.Core.Contexts
{
    public class DotnetWebApiDDDDbContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountsTransactions> AccountsTransactions { get; set; }

        public DotnetWebApiDDDDbContext(DbContextOptions<DotnetWebApiDDDDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsMapping());
            modelBuilder.ApplyConfiguration(new AccountsMapping());
            modelBuilder.ApplyConfiguration(new AccountsTransactionsMapping());
        }
    }
}
