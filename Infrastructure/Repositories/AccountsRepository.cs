using System;
using Infrastructure.Database.Core.Contexts;
using Infrastructure.Database.Core.Factories;
using Domain.Domain.Core.Consts;
using Domain.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Core
{
    public class AccountsRepository : IAccountsRepository
    {
        public async Task<Accounts> GetAccount(string accountNumber)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return await context.Accounts.Include(a => a.Client).FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Accounts> GetAccount(long clientId)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return await context.Accounts.Include(a => a.Client).FirstOrDefaultAsync(a => a.Client.Id == clientId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddAccount(Accounts account)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Entry(account.Client).State = EntityState.Unchanged;

                    await context.Accounts.AddAsync(account);

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAccount(Accounts account)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Accounts.Update(account);

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
