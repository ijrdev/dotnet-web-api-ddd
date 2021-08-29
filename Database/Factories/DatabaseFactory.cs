using Database.Contexts;
using Domain.Consts;
using Microsoft.EntityFrameworkCore;

namespace Database.Factories
{
    public static class DatabaseFactory
    {
        public static dynamic CreateConnection(string database)
        {
            switch (database)
            {
                case DatabaseConnections.DOTNET_WEB_API_DDD:
                    return new DbContextOptionsBuilder<DotnetWebApiDDDDbContext>()
                        .UseSqlServer("Server=DESKTOP-ELFNCSC\\SQLEXPRESS;Database=dotnet_web_api_ddd;Trusted_Connection=True;")
                        // .UseLazyLoadingProxies()
                        .Options;

                default:
                    return null;
            }
        }
    }
}
