using Database.Contexts;
using Database.Factories;
using Domain.Consts;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Entities;
using Domain.Exceptions;

namespace Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        public Clients GetClient(string documentEmail)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Document == documentEmail || c.Email == documentEmail).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Clients GetClient(long id)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Id == id).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddClient(Clients client)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.AddAsync(client);

                    context.SaveChangesAsync().GetAwaiter().GetResult();
                }
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateClient(Clients client)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Update(client);

                    context.SaveChangesAsync().GetAwaiter().GetResult();
                }
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
