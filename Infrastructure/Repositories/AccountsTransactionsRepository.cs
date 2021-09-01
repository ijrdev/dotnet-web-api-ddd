using Infrastructure.Database.Core.Contexts;
using Infrastructure.Database.Core.Factories;
using Domain.Domain.Core.Consts;
using Domain.Domain.Core.Entities;
using Domain.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories.Core
{
    public class AccountsTransactionsRepository : IAccountsTransactionsRepository
    {
        public void Register(AccountsTransactions accountTransaction)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Entry(accountTransaction.Account).State = EntityState.Unchanged;

                    context.AccountsTransactions.AddAsync(accountTransaction).GetAwaiter().GetResult();

                    context.SaveChangesAsync().GetAwaiter().GetResult();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AccountsTransactions> GetStatements(long accountId)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.AccountsTransactions.Where(a => a.Account.Id == accountId).ToListAsync().GetAwaiter().GetResult();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
