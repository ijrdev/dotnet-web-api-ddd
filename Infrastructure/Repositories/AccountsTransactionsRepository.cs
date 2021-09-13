using Infrastructure.Database.Core.Contexts;
using Infrastructure.Database.Core.Factories;
using Domain.Domain.Core.Consts;
using Domain.Domain.Core.Entities;
using Domain.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Core
{
    public class AccountsTransactionsRepository : IAccountsTransactionsRepository
    {
        public async Task Register(AccountsTransactions accountTransaction)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Entry(accountTransaction.Account).State = EntityState.Unchanged;

                    await context.AccountsTransactions.AddAsync(accountTransaction);

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AccountsTransactions>> GetStatements(long accountId)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return await context.AccountsTransactions.Where(a => a.Account.Id == accountId).ToListAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
