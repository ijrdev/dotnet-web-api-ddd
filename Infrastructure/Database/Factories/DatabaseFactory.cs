using Infrastructure.Database.Core.Contexts;
using Domain.Domain.Core.Consts;
using Microsoft.EntityFrameworkCore;
using Infrastructure.CrossCutting.Core;

namespace Infrastructure.Database.Core.Factories
{
    public static class DatabaseFactory
    {
        public static dynamic CreateConnection(string database)
        {
            switch (database)
            {
                case DatabaseConnections.DOTNET_WEB_API_DDD:
                    return new DbContextOptionsBuilder<DotnetWebApiDDDDbContext>()
                        .UseSqlServer($"Server={InternalConfiguration.AppSettings["ConnectionStrings:Server"]};Database={InternalConfiguration.AppSettings["ConnectionStrings:Database"]};Trusted_Connection=True;")
                        // .UseLazyLoadingProxies()
                        .Options;

                default:
                    return null;
            }
        }
    }
}
