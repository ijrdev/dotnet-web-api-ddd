using Infrastructure.Database.Core.Contexts;
using Domain.Domain.Core.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Database.Core.Factories
{
    public static class DatabaseFactory
    {
        private static readonly IConfiguration _iConfiguration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        public static dynamic CreateConnection(string database)
        {
            switch (database)
            {
                case DatabaseConnections.DOTNET_WEB_API_DDD:
                    return new DbContextOptionsBuilder<DotnetWebApiDDDDbContext>()
                        .UseSqlServer($"Server={_iConfiguration["ConnectionStrings:Server"]};Database={_iConfiguration["ConnectionStrings:Database"]};Trusted_Connection=True;")
                        // .UseLazyLoadingProxies()
                        .Options;

                default:
                    return null;
            }
        }
    }
}
