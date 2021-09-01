using System;
using Infrastructure.Database.Core.Contexts;
using Infrastructure.Database.Core.Factories;
using Domain.Domain.Core.Consts;
using Domain.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Domain.Core.Entities;

namespace Infrastructure.Repositories.Core
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
