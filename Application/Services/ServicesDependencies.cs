using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class ServicesDependencies
    {
        public static void InjectServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<IAccountsService, AccountsService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAccountsTransactionsService, AccountsTransactionsService>();
        }
    }
}
