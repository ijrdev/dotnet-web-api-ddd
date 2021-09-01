using Domain.Domain.Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories.Core
{
    public static class RepositoriesDependencies
    {
        public static void InjectRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<IAccountsRepository, AccountsRepository>();
            services.AddTransient<IAccountsTransactionsRepository, AccountsTransactionsRepository>();
        }
    }
}
