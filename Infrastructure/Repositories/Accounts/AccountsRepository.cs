using System;
using Database.Contexts;
using Database.Factories;
using Domains.Database;
using Interfaces.Repositories.Accounts;
using Domain = Domains.Accounts;

namespace Repositories.Accounts
{
    public class AccountsRepository : IAccountsRepository
    {
        public void AddAccount(Domain.Accounts account)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    context.Accounts.AddAsync(account).GetAwaiter().GetResult();

                    context.SaveChangesAsync().GetAwaiter().GetResult();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
