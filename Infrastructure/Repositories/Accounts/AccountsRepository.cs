using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contexts;
using Database.Factories;
using Domains.Database;
using Interfaces.Repositories.Accounts;
using Microsoft.EntityFrameworkCore;
using Domain = Domains.Accounts;

namespace Repositories.Accounts
{
    public class AccountsRepository : IAccountsRepository
    {
        public Domain.Accounts GetAccount(string accountNumber)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    return context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Domain.Accounts> GetAccounts(long clientId)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    return context.Accounts.Where(a => a.Client.Id == clientId).ToListAsync().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddAccount(Domain.Accounts account)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    context.Accounts.Add(account);

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
