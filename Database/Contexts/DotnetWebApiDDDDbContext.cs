using Domains.Clients;
using Domains.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Database.Contexts
{
    public class DotnetWebApiDDDDbContext : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ClientsContacts> ClientsContacts { get; set; }
        public DbSet<ClientsAddresses> ClientsAddresses { get; set; }

        public DotnetWebApiDDDDbContext(DbContextOptions<DotnetWebApiDDDDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
            // optionsBuilder.UseSqlServer(DatabaseConnectionString.DOTNET_WEB_API_DDD_CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
