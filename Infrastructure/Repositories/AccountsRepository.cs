using System;
using Database.Contexts;
using Database.Factories;
using Domain.Consts;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        public Accounts GetAccount(string accountNumber)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.Accounts.Include(a => a.Client).FirstOrDefaultAsync(a => a.AccountNumber == accountNumber).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Accounts GetAccount(long clientId)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.Accounts.Include(a => a.Client).FirstOrDefaultAsync(a => a.Client.Id == clientId).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddAccount(Accounts account)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Entry(account.Client).State = EntityState.Unchanged;

                    context.Accounts.AddAsync(account).GetAwaiter().GetResult();

                    context.SaveChangesAsync().GetAwaiter().GetResult();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateAccount(Accounts account)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Accounts.Update(account);

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
