using Database.Contexts;
using Database.Factories;
using Domain.Database;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repositories
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
    }
}
