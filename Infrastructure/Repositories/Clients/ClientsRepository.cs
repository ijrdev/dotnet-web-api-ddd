using CrossCutting;
using Database.Contexts;
using Database.Factories;
using Domains.Database;
using Domains.Helpers;
using Interfaces.Repositories.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace Repositories.Clients
{
    public class ClientsRepository : IClientsRepository
    {
        public Domains.Clients.Clients GetClient(string document)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Document == document).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Domains.Clients.Clients GetClient(long id)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Id == id).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateClient(long id, Domains.Clients.Clients client)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    Domains.Clients.Clients clientResult = context.Clients.FindAsync(id).GetAwaiter().GetResult();

                    if (clientResult == null)
                    {
                        throw new CustomException(HttpStatusCode.NotFound, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND);
                    }

                    client.Id = id;

                    context.Entry(clientResult).CurrentValues.SetValues(client);
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
