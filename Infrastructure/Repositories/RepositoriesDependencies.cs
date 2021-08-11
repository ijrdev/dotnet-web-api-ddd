using Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories
{
    public static class RepositoriesDependencies
    {
        public static void InjectRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientsRepository, ClientsRepository>();
        }
    }
}
