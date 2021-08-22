using Database.Contexts;
using Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database.Factories
{
    public static class DatabaseFactory
    {
        private static IConfiguration Configuration;

        public static dynamic CreateConnection(string database)
        {
            switch(database)
            {
                case DatabaseConnections.DOTNET_WEB_API_DDD:
                    return new DbContextOptionsBuilder<DotnetWebApiDDDDbContext>()
                        .UseSqlServer($"Server={Configuration.GetSection("ConnectionStrings")["Server"]};Database={Configuration.GetSection("ConnectionStrings")["Database"]};Trusted_Connection=True;")
                        // .UseLazyLoadingProxies()
                        .Options;

                default:
                    return null;
            }
        }
    }
}
