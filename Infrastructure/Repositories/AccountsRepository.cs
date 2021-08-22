﻿using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contexts;
using Database.Factories;
using Domain.Database;
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
                    return context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Accounts> GetAccounts(long clientId)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.Accounts.Where(a => a.Client.Id == clientId).ToListAsync().GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddAccount(Accounts account, bool newClient = false)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    if(!newClient)
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
    }
}