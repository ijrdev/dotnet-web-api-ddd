using Infrastructure.Database.Core.Contexts;
using Infrastructure.Database.Core.Factories;
using Domain.Domain.Core.Consts;
using Domain.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Domain.Core.Entities;
using Domain.Domain.Core.Exceptions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Core
{
    public class ClientsRepository : IClientsRepository
    {
        public async Task<Clients> GetClient(string documentEmail)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return await context.Clients.FirstOrDefaultAsync(c => c.Document == documentEmail || c.Email == documentEmail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Clients> GetClient(long id)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return await context.Clients.FirstOrDefaultAsync(c => c.Id == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddClient(Clients client)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    await context.AddAsync(client);

                    await context.SaveChangesAsync();
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

        public async Task UpdateClient(Clients client)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    context.Update(client);

                    await context.SaveChangesAsync();
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
