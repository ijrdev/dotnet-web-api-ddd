using Interfaces.Services.Clients;
using Microsoft.Extensions.DependencyInjection;
using Services.Clients;

namespace Services
{
    public static class ServicesDependencies
    {
        public static void InjectServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientsService, ClientsService>();
        }
    }
}
