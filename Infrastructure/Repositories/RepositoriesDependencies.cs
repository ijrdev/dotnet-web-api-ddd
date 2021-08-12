using Interfaces.Repositories.Clients;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Clients;

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
