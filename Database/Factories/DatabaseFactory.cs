using Database.Contexts;
using Domains.Database;
using Microsoft.EntityFrameworkCore;

namespace Database.Factories
{
    public static class DatabaseFactory
    {
        public static dynamic CreateConnection(string database)
        {
            switch(database)
            {
                case DatabaseConnectionString.DOTNET_WEB_API_DDD:
                    //return DatabaseConnectionString.DOTNET_WEB_API_DDD_CONNECTION_STRING;
                    return new DbContextOptionsBuilder<DotnetWebApiDDDDbContext>()
                        .UseSqlServer(DatabaseConnectionString.DOTNET_WEB_API_DDD_CONNECTION_STRING)
                        // .UseLazyLoadingProxies()
                        .Options;

                default:
                    return null;
            }
        }
    }
}
