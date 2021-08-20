using Interfaces.Repositories.Accounts;
using Interfaces.Repositories.Auth;
using Interfaces.Repositories.Clients;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Accounts;
using Repositories.Auth;
using Repositories.Clients;

namespace Repositories
{
    public static class RepositoriesDependencies
    {
        public static void InjectRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<IAccountsRepository, AccountsRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
        }
    }
}
